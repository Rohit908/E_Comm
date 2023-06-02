var datatable;

function loadDataTable(tableId, url, columns) {
    datatable = $("#productTable").DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "title" },
            { "data": "isbn" },
            { "data": "price" },
            { "data": "author" },
            { "data": "category.name" },
            { "data": "coverType.name" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <a class="btn btn-info" href="/Admin/Product/Upsert?id=${data}"><i class="bi bi-pencil-square"></i> Edit</a>  
                    <a class="btn btn-danger" onclick=Delete('/Admin/Product/Delete/${data}')><i class="bi bi-trash"></i> Delete</a>
                    `
                },
                "width": "15%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "You wont be able to revert this!",
        type: "warning",
        buttons: true,
        confirmButtonColor: '#DD6B55',
        confirmButtonText: 'Yes, I am sure!',
        cancelButtonText: "No, cancel it!",
        closeOnConfirm: false,
        closeOnCancel: false
    }).then(
        function (isConfirm) {
            if (isConfirm) {
                $.ajax({
                    url: url,
                    type: "DELETE",
                    success: function (data) {
                        if (data.success) {
                            datatable.ajax.reload();
                            toastr.success(data.message);
                        }
                        else {
                            toastr.error(data.message);
                        }
                    }
                });

            }
        });
}
