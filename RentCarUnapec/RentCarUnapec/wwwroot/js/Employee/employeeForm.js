$(document).ready(function() {
    setCedulaMask(document.getElementById('Employee_IdentityNumber'));
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
    
};