$(document).ready(function () {
    if ($('#ManufacturerList').val() > 0) {
        $('#ModelList').prop("disabled", false);
    } else {
        $('#ModelList').prop("disabled", true);
    }

    $('#ManufacturerList').on('change', function () {
        getCarModels(this.value);
    });

    validateDate();

    $('#FromDate').on('change',
        function () {
            validateDate();
        });

    $('#ToDate').on('change',
        function () {
            validateDate();
        });
});

function getCarModels(manufacturerId) {
    var modelSelect = $('#ModelList');

    $.get('http://localhost:5000/api/Models/ByManufacturer/' + manufacturerId).done(function (data) {
        modelSelect.empty();
        modelSelect.append(getDefaultSelect());
        if (data.length <= 0) {
            modelSelect.prop("disabled", true);
            //modelSelect.append(getDefaultSelect());
        } else {
            modelSelect.prop("disabled", false);
            $.each(data, function (index, optionData) {
                modelSelect.append("<option value='" + optionData.value + "'>" + optionData.text + "</option>");
            });
        }

    });
};

function getDefaultSelect() {
    return "<option>Todos</option>";
};

function cleanForm() {
    document.getElementById("ModelList").selectedIndex = "0";
    document.getElementById("ModelList").disabled = true;
    document.getElementById("ManufacturerList").selectedIndex = "0";
    document.getElementById("TypeList").selectedIndex = "0";
    document.getElementById("ClientId").value = "0";
    document.getElementById("ClientName").value = "";
    document.getElementById("SearchDone").value = false;
    document.getElementById("reportBtn").hidden = true;
}

function validateDate() {
    var fromDate = document.getElementById("FromDate").value;
    var toDate = document.getElementById("ToDate").value;
    document.getElementById("dateValidation").hidden = (fromDate <= toDate);
    document.getElementById("searchBtn").disabled = !(fromDate <= toDate);
};

function report() {
    $.get("/Report/GetCarRentReport/",
        {
            manufacturerId: document.getElementById("ManufacturerList").value,
            modeId: document.getElementById("ModelList").value
        },
        function (data) {

        });
}