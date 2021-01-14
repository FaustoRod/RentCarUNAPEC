var createUrl = apiUrl + "/api/VehicleTypes/Create";
var deleteUrl = apiUrl + "/api/VehicleTypes/Delete/";
var editUrl = apiUrl + "/api/VehicleTypes/Edit/";

$(document).ready(function () {
    $("#vehicleTypeEditModal").on("show.bs.modal",
        function (event) {

            var button = $(event.relatedTarget);

            var typeId = button.data('typeid');
            var typeName = button.data('typename');

            console.log(typeId);

            $('.editForm #Description').val(typeName);
            $('.editForm #Id').val(typeId);
        });

    $("#vehicleTypeDeleteModal").on("show.bs.modal",
        function (event) {

            var button = $(event.relatedTarget);
            console.log(button.data('what'));
            console.log(button.data('typename'));

            var typeId = button.data('typeid');
            var typeName = button.data('typename');

            $('#vehicleTypeId').val(typeId);
            $('#descriptionName').html(typeName);
        });

    $("#vehicleTypeDeleteModal").on("hidden.bs.modal",
        function (event) {
            $('#vehicleTypeId').val('');
            $('#descriptionName').html('');
        });

    $("#vehicleTypeCreateModal").on("hidden.bs.modal",
        function (event) {
            $('#Description').val('');
        });

    $("#vehicleTypeEditModal").on("hidden.bs.modal",
        function (event) {
            $('.editForm #Description').val('');
        });
});

function createVehicleType() {
    $("#createForm").validate();

    if ($("#createForm").valid()) {
        var type = { Description: $('#Description').val() };

        $.ajax({
            type: 'POST',
            url: createUrl,
            contentType: 'application/json',
            data: JSON.stringify(type),
            success: function (result) {
                console.log('Data received: ');
                console.log(result);
            }
        }).done(function (data) {
            getVehicleTypeList();
            swal("CREADO CON EXITO", "El Tipo de Vehiculo " + type.Description + " fue creado exitosamente", "success");
            createModalHide();
        }).fail(function (data) {
            swal({
                title: "Error",
                text: "Error al Crear Tipo de Vehiculo " + type.Description,
                icon: "error"
            });
        });;
    }

}

function editVehicleType() {
    $("#editForm").validate();
    
    if ($("#editForm").valid()) {
        var type = { Id: $('.editForm #Id').val(),Description: $('.editForm #Description').val() };

        $.ajax({
            type: 'PUT',
            url: editUrl,
            contentType: 'application/json',
            data: JSON.stringify(type),
            success: function (result) {
                console.log('Data received: ');
                console.log(result);
            }
        }).done(function () {
            getVehicleTypeList();
            editModalHide();
            alert('MODIFICADO CON EXITO');
        }).fail(function (data) {
            alert("NO OKAY");
        });;
    }

}

function deleteVehicleType() {
    var typeId = $('#vehicleTypeId').val();

    if ($("#createForm").valid()) {

        $.ajax({
            type: 'DELETE',
            url: deleteUrl + typeId,
            success: function (result) {
                console.log('Data received: ');
                console.log(result);
            }
        }).done(function (data) {
            getVehicleTypeList();
            deleteModalHide();
            alert('ELIMINADO CON EXITO');
        }).fail(function (data) {
            alert("NO OKAY");
        });;
    }
}

function getVehicleTypeList() {
    $.get('/VehicleType/GetList',
        function (data) {
            $('#vehicleTypeTable').empty();
            $('#vehicleTypeTable').html(data);
        });
}

function createModalHide() {
    $('#Description').val('');
    $('#vehicleTypeCreateModal').modal('hide');
}
function editModalHide() {
    $('.editForm #Description').val('');
    $('#vehicleTypeEditModal').modal('hide');
}

function deleteModalHide() {
    $('#vehicleTypeDeleteModal').modal('hide');
}