$(document).ready(function () {
    getManufacturers();

    $('#vehicleSearchModal').on('hidden.bs.modal', function (e) {
        $('#vehicleSearchBody').html('');
    });
});

function getManufacturers() {
    var modelSelect = $('#vehicleSearchManufacturerId');
    //alert(modelSelect);
    //$.get('/Manufacturer/GetManufacturers').done(function (data) {
    $.get('/Manufacturer/GetManufacturers').done(function (data) {
        modelSelect.empty();
        if (data.length <= 0) {

        } else {
            $.each(data, function (index, optionData) {
                modelSelect.append("<option value='" + optionData.value + "'>" + optionData.text + "</option>");
            });
            //$('#vehicleSearchModelId').append(getDefaultSelect);
            getModels();
        }
        //alert(cars[0].value);
    });
};

function getModels() {
    var modelSelect = $('#vehicleSearchModelId');
    //alert(modelSelect);
    $.get('http://localhost:5000/api/Models/ByManufacturer/' + $('#vehicleSearchManufacturerId').val()).done(function (data) {
        modelSelect.empty();
        if (data.length <= 0) {
            alert("NO");

        } else {
            modelSelect.append(getDefaultSelect());
            $.each(data, function (index, optionData) {
                modelSelect.append("<option value='" + optionData.value + "'>" + optionData.text + "</option>");
            });
        }
        getVehicles();

    });
}

function getDefaultSelect() {
    return '<option value="0"> Todos </option>';
};

function getVehicles() {
    var modelSelect = $('#vehicleSearchBody');
    var selectedValue = $('#vehicleSearchModelId').val();
    if (selectedValue > 0) {
        getVehicleByModels(modelSelect);
    } else {
        getVehicleByManufacturer(modelSelect);
    }
};

function getVehicleByModels(tableBody) {
    $.get('/Vehicle/GetByModel', { id: $('#vehicleSearchModelId').val() }).done(function (data) {
    //$.get(apiUrl + '/api/Vehicles/Model/' + $('#vehicleSearchModelId').val()).done(function (data) {
        tableBody.empty();
        tableBody.html(data);
    });
};

function getVehicleByManufacturer(tableBody) {
    $.get('/Vehicle/GetByManufacturer', { id: $('#vehicleSearchManufacturerId').val() }).done(function (data) {
        tableBody.empty();
        tableBody.html(data);
    });
};

function getVehicleInfo(control) {
    $('#vehicleInfo').val($(control).attr('data-vehicleName'));
    $('#vehicleInfoColor').val($(control).attr('data-vehicleColor'));
    $('#vehicleInfoPlate').val($(control).attr('data-vehiclePlate'));
    $('#CarRentInformation_VehicleId').val($(control).attr('id'));
    $('#vehicleSearchModal').modal('hide');
};