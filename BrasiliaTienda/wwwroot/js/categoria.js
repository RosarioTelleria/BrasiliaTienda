var $datatable;

$(document).ready(() => {
    cargarDataTable();
});


function cargarDataTable() {
    $datatable = $('#tblcategorias').DataTable({
        "ajax": {
            "url": "/Admin/Categoria/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "nombre", "width": "5%" },
            { "data": "orden", "width": "5%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href='/Admin/Categoria/Edit/${data}' class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                    <i class='fas fa-edit'></i> Editar
                                </a>
                                &nbsp;
                                <a onclick='Delete("/Admin/Categoria/Delete/${data}")' class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                                    <i class='fas fa-'></i> Borrar
                                </a>
                            </div>`;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No hay registros"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Esta seguro de borrar?",
        text: "Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, borrar!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    $datatable.ajax.reload();
                } else {
                    toastr.error(data.message);
                }
            }
        });
    });
}