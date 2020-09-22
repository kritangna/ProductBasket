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
                           <div class="text-center">
                                <a class="btn btn-success text-white" href="/Admin/Product/Upsert?id=${data}" style="cursor:pointer">
                                    Edit
                                </a>
                                <a onclick=Delete("/Admin/Product/Delete?id=${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                   Del
                                </a>
                           </div>
                           `;

                }, "width": "30%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to delete?",
        text: "Once deleted can not be retrieved!",
        icon: "warning",
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
            })
        }
    });
}