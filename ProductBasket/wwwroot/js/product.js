var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll",
            "type": "GET",
            "datatype":"json"
        },
        "columns": [
            { "data": "prodName", "width": "20%" },
            { "data": "prodImageName", "width": "20%" },
            { "data": "prodPrice", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                           <div class="text-center>
                                <a class="btn btn-danger text-white" href="/Admin/Product/Upsert?id=${data}" style="cursor:pointer">
                                    Edit
                                </a>
                                <a class="btn btn-danger text-white" style="cursor:pointer">
                                   Del
                                </a>
                           </div>
                           `;

                }, "width": "30%"
            }
        ]
    });
}