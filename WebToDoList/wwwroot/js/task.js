var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/TeamLeader/Task/GetAll"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "dedscription", "width": "20%" },
            { "data": "taskType.Type", "width": "20%" },
            { "data": "employee.Name", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
<div class="text-center">
    <a href="/TeamLeader/Task/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
        <i class="fas fa-edit"></i> 
    </a>
    <a onClick=Delete("/TeamLeader/Task/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
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