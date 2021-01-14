var createUrl = apiUrl + "/api/Models/Create";
var deleteUrl = apiUrl + "/api/Models/Delete/";
var editUrl = apiUrl + "/api/Models/Edit/";
var allUrl = "/Models";

$(document).ready(function () {
    getManufacturerSelectList();
    $("#modelEditModal").on("show.bs.modal",
        function (event) {

            var button = $(event.relatedTarget);

            var typeId = button.data('typeid');
            var typeName = button.data('typename');
            var manufacturerId = button.data('manufacturerid');

            console.log(typeId);

            $('.editForm #Description').val(typeName);
            $('.editForm #ManufacturerId').val(manufacturerId);
            $('#modelId').val(typeId);
        });

    $("#modelDeleteModal").on("show.bs.modal",
        function (event) {

            var button = $(event.relatedTarget);

            var typeId = button.data('typeid');
            var typeName = button.data('typename');
            var manufacturer = button.data('manufacturer');

            $('#modelId').val(typeId);
            $('#descriptionName').html(typeName);
            $('#manufacturer').html(manufacturer);
        });

    $("#modelDeleteModal").on("hidden.bs.modal",
        function () {
            $('#vehicleTypeId').val('');
            $('#descriptionName').html('');
            $('#manufacturer').html('');
        });


    $("#modelCreateModal").on("hidden.bs.modal",
        function (event) {
            $('#Description').val('');
            $("#ManufacturerId").prop('selectedIndex', 0);
        });

    $("#modelEditModal").on("hidden.bs.modal",
        function (event) {
            $('.editForm #Description').val('');
            $(".editForm #ManufacturerId").prop('selectedIndex', 0);
        });
});

function getManufacturerSelectList() {
    var createModelSelect = $('#ManufacturerId');
    var editModelSelect = $('.editForm #ManufacturerId');

    $.get('http://localhost:5000/api/Manufacturer/ManufacturerAll').done(function (data) {
        createModelSelect.empty();
        if (data.length <= 0) {
            createModelSelect.prop("disabled", true);
            //modelSelect.append(getDefaultSelect());
        } else {
            createModelSelect.prop("disabled", false);
            $.each(data, function (index, optionData) {
                createModelSelect.append("<option value='" + optionData.value + "'>" + optionData.text + "</option>");
                editModelSelect.append("<option value='" + optionData.value + "'>" + optionData.text + "</option>");
            });
        }

    });
};

function createModel() {
    $("#createForm").validate();

    if ($("#createForm").valid()) {
        var model = { ManufacturerId: $('#ManufacturerId').val(),Description: $('#Description').val() };

        $.ajax({
            type: 'POST',
            url: createUrl,
            contentType: 'application/json',
            data: JSON.stringify(model),
            success: function (result) {
                console.log('Data received: ');
                console.log(result);
            }
        }).done(function (data) {
            getModelList();
            swal("CREADO CON EXITO", "El Modelo " + model.Description + " fue creado exitosamente","success");
            createModalHide();
        }).fail(function (data) {
            swal({
                title: "Error",
                text: "Error al Crear Modelo " + model.Description,
                icon:"error"
            });
        });;
    }
}
function editModel() {
    $("#editForm").validate();

    if ($("#editForm").valid()) {
        var model = {
            Id: $('#modelId').val(),
            ManufacturerId: $('.editForm #ManufacturerId').val(),
            Description: $('.editForm #Description').val()
        };

        $.ajax({
            type: 'PUT',
            url: editUrl,
            contentType: 'application/json',
            data: JSON.stringify(model),
            success: function (result) {
                console.log('Data received: ');
                console.log(result);
            }
        }).done(function (data) {
            getModelList();
            swal("MODIFICADO CON EXITO", "El Modelo " + model.Description + " Fue Modificado Exitosamente", "success");
            editModalHide();
        }).fail(function (data) {
            swal({
                title: "Error",
                text: "Error al Modificar Modelo " + model.Description,
                icon: "error"
            });
        });;
    }
}
function deleteModel() {
    var modelId = $('#modelId').val();

    $.ajax({
        type: 'DELETE',
        url: deleteUrl + modelId,
        success: function (result) {
        }
    }).done(function (data) {
        getModelList();
        swal("Eliminado CON EXITO", "El Modelo " + $('#descriptionName').html() + " fue eliminado exitosamente", "success");
        deleteModalHide();
    }).fail(function (data) {
        swal({
            title: "Error",
            text: "Error al Eliminar Modelo " + $('#descriptionName').html(),
            icon: "error"
        });
    });;
}

function getModelList() {
    $.get(allUrl,
        function (data) {
            $('#modelTableList').empty();
            $('#modelTableList').html(data);
        });
}

function createModalHide() {
    $('#modelCreateModal').modal('hide');
}
function editModalHide() {
    $('#modelEditModal').modal('hide');
}

function deleteModalHide() {
    $('#modelDeleteModal').modal('hide');
}