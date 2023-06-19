var datatable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $("#companyTable").DataTable({
        "ajax": {
            "url":"/Admin/Company/GetAll"
        },
        "columns": [
            { "data": "name", "width": "100/6" },
            { "data": "streetAddress", "width": "100/6" },
            { "data": "city", "width": "100/6" },
            { "data": "state", "width": "100/6" },
            { "data": "phoneNumber", "width": "100/6" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <a class="btn btn-info" href="/Admin/Company/Upsert?id=${data}"><i class="bi bi-pencil-square"></i> Edit</a>
                    <a class="btn btn-danger" onclick=Delete('/Admin/Company/Delete/${data}')><i class="bi bi-trash"></i> Delete</a>
                    `
                },
                "width":"100/6"
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
