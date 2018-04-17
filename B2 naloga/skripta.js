var uri = 'api/osebe';

$(document).ready(function () {
    // Send an AJAX request
    $.getJSON(uri)
        .done(function (data) {
            zapolniPodatke(JSON.parse(data));
        });

    $(".lokalno").on('click', function (e) {
            // da mi ne submita forma --> ne doda vrstice
        e.preventDefault();
        var podatki = pridobiPodatke();
        $('#osebe').append(formatiraj(podatki));
            // spremeni stevilo oseb
        $('#stOseb').text(podatki.id);
    });
    $(".streznik").on('click', function (e) {
            // da mi ne submita forma --> ne doda vrstice
        e.preventDefault();
        var podatki = pridobiPodatke();
        $.ajax({
            type: "POST",
            url: uri,
            data: { podatki },
            success: function (data) {
                console.log(data);
                // izprazni trenutne podatke
                $('#osebe tbody tr').remove();
                $.getJSON(uri)
                    .done(function (data) {
                        zapolniPodatke(JSON.parse(data));
                    });
            }
        });
    });
});

function zapolniPodatke(json) {
    $('#stOseb').text(json.length);
        // iteriram po podatkih
    $.each(json, function (key, item) {
        var data = formatiraj(item);
        $('#osebe').append(data);
    });
}

function pridobiPodatke() {
    var podatki = {
        id: parseInt($('#stOseb').text()) + 1,
        ime: $('input[name="imeOsebe"]').val(),
        starost: $('input[name="starostOsebe"]').val()
    }
    $('.forma input[type="text"]').val('');
    $('.forma input[type="number"]').val('');
    return podatki;
}

function formatiraj(item) {
    var data = 
    '<tr>'
        + '<th>' + item.id + '</th>'
        + '<th>' + item.ime + '</th>'
        + '<th>' + item.starost + '</th>' +
        '</tr>';
    return data;
}