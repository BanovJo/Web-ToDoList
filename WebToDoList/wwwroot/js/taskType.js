var dataTable;

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
    <a href="/TemLeader/TaskType/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
        <i class="fas fa-edit"></i> 
    </a>
    <a class="btn btn-danger text-white" style="cursor:pointer">
        <i class="fas fa-trash"></i>
    </a>
</div>
                         `;
                      
                }, "width": "40%"
            }
        ]
    });
}