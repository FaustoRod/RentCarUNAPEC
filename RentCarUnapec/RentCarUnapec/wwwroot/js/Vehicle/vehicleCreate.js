$(document).ready(function () {
    $('#ManufacturerId').on('change', function () {
        getCarModels(this.value);
    });
});

function getCarModels(manufacturerId) {
    //$.get("/Vehicle/Create/GetModelList", function (data) {
    //    alert(data);
    //});
    var modelSelect = $('#Vehicle_ModelId');
    $.get('/Vehicle/Create?handler=GetModelList', { id: manufacturerId }).done(function (data) {
        modelSelect.empty();
        if (data.length <= 0) {
            modelSelect.prop("disabled", true);
            modelSelect.append(getDefaultSelect());
        } else {
            modelSelect.prop("disabled", false);
            $.each(data, function (index, optionData) {
                modelSelect.append("<option value='" + optionData.value + "'>" + optionData.text + "</option>");
            });
        }
        
        
        //alert(cars[0].value);
    });
};

function getDefaultSelect() {
    return "<option> Seleccione </option>";
};