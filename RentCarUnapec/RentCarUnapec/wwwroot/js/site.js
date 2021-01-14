$(document).ready(function () {
    $(".letterOnlyInput").keypress(function (event) {
        var inputValue = event.charCode;
        if (evalLetter(inputValue)) {
            event.preventDefault();
        }
    });

    $(".numberOnlyInput").keypress(function (event) {
        var inputValue = event.charCode;
        if (evalNumber(inputValue)) {
            event.preventDefault();
        }
    });

    $(".alphaNumberOnlyInputNoSpace").keypress(function (event) {
        var inputValue = event.charCode;
        if (!(inputValue >= 48 && inputValue <= 57) &&
            !((inputValue >= 65 && inputValue <= 122) && (inputValue != 32 && inputValue != 0))) {
            event.preventDefault();
        }

    });

    $(".alphaNumberOnlyInput").keypress(function (event) {
        var inputValue = event.charCode;
        if (evalNumber(inputValue) && evalLetter(inputValue)) {
            event.preventDefault();
        }
    });
    
});

function toUpperCaseInput(control) {
    control.value = control.value.toUpperCase();
};

function evalLetter(inputValue) {
    //alert((inputValue >= 65 && inputValue <= 120) && (inputValue != 32 && inputValue != 0));
    return !(inputValue >= 65 && inputValue <= 122) && (inputValue != 32 && inputValue != 0);
};

function evalNumber(inputValue) {
    //alert(!(inputValue >= 48 && inputValue <= 57));
    return !(inputValue >= 48 && inputValue <= 57);
};

const apiUrl = "http://localhost:5000";