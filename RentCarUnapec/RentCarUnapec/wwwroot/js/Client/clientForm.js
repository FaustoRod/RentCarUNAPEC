$(document).ready(function() {
    setCedulaMask(document.getElementById('Client_IdentityNumber'));
});

function setCedulaMask(control) {
    var maskOption = {
        mask: '000-0000000-0'
        //,
        //lazy: false,
        //placeholder: '000-0000000-0',
        //placeholderChar:'0'
    };

    var mask = IMask(control, maskOption);

    mask.on("complete", function () {
        if (document.getElementById('Client_IdentificationType').value == 1) {
            validateCedula(mask.unmaskedValue);
        }
    });
    
};

function validateCedula(cedula) {
    $.get('/Client/ValidateCedula/',
        { cedula: cedula },
        function(data) {
            if (data) {
                document.getElementById('invalidaCedula').hidden = true;
                document.getElementById('validaCedula').hidden = false;
                document.getElementById('clientGuardarBtn').disabled  = false;
            } else {
                document.getElementById('invalidaCedula').hidden = false;
                document.getElementById('validaCedula').hidden = true;
                document.getElementById('clientGuardarBtn').disabled = true;
            }
        });
};

function validateForm() {
    if (document.getElementById('Client_IdentityNumber').value.length != 13) {
        document.getElementById('invalidaCedula').hidden = false;
        return false;
    }

    document.getElementById('invalidaCedula').hidden = true;
    return true;
}

function validateClientType() {
    var clientType = document.getElementById('Client_ClientType').value;
    if (clientType == 1) {
        document.getElementById('Client_IdentificationType').disabled = false;
        document.getElementById('Client_IdentificationType').value = 1;

    } else {
        document.getElementById('Client_IdentificationType').value = 2;
        document.getElementById('Client_IdentificationType').disabled = true;
    }
    
}

function clearIdentification() {
    document.getElementById('invalidaCedula').hidden = true;
    document.getElementById('validaCedula').hidden = true;
    document.getElementById('Client_IdentityNumber').value = '';
    document.getElementById('clientGuardarBtn').disabled = false;

}