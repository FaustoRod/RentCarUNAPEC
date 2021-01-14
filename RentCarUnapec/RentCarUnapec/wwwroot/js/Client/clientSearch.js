$(document).ready(function() {
    $('#clientSearchModal').on('hidden.bs.modal', function(e) {
        $('#clientSearchBody').html('');

        
    });
});

function getClients() {
    $.get('/Client/GetClients', { name: $('#clientName').val(), identification: $('#clientIdentity').val() }).done(function (data) {
        $('#clientSearchBody').html(data);
    });
};

function getClientInfo(control) {
    $('#CarRentInformation_ClientId').val($(control).attr('id'));
    $('#clientInfo').val($(control).attr('data-name'));
    $('#clientInfoIdentity').val($(control).attr('data-identity'));
    $('#clientSearchModal').modal('hide');
};