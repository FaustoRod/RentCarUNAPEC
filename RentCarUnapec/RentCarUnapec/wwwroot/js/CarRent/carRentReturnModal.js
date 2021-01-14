$(document).ready(function() {
    $('#carRentReturnModal').on('show.bs.modal', function (event) {
        var sender = $(event.relatedTarget);
        $('#carRentId').val(sender.data('carrentid'));
        $('#nombreVehiculo').html(sender.data('vehiclename'));
        $('#nombreCliente').html(sender.data('client'));
    });
});

function SaveReturn() {
    $.post('/RentReturn/Create', { id: $('#carRentId').val()}).done(function(data) {
        if (data == true) {
            location.reload();
        }
    });
}