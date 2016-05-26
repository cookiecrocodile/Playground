$(document).ready(function () {

    $.ajax({
        url: "/Api/GetPawns",
        dataType: 'json',
        data: {},
        success: function (data) {
            //$("#pawnlist").html(data);

            for (var i = 0; i < data.length; i++) {

                var option = $("<option></option>").text(data[i].Type);
                $("#pawnlist").append(option);

            }


        },
        error: function (jqHXR, statusText, errorThrown) {
            $("#pawnlist").html("Not working!\n" + statusText+"\n" + errorThrown);
        }
    });

});