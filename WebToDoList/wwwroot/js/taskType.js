﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/TeamLeader/TaskType/GetAll"
        },
        "columns": [
            { "data": "type", "width": "60%" },
            {
                "data": "taskTypeId",
                "render": function (data) {
                    return `
<div class="text-center">
    <a href="/TeamLeader/TaskType/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
        <i class="fas fa-edit"></i> 
    </a>
    <a onClick=Delete("/TeamLeader/TaskType/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
        <i class="fas fa-trash"></i>
    </a>
</div>
                         `;
                      
                }, "width": "40%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        icon: "warning",
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}