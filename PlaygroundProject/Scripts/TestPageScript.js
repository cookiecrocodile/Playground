$(document).ready(function () {

    $.ajax({
        url: "/Api/GetRanks",
        dataType: 'json',
        data: {},
        success: function (data) {
           

            var addThis = "<tr><th>Rank Name</th></tr>"
            
            for (var i = 0; i < data.length; i++) {

                var tablerow = "<tr><td>" + data[i].RankName + "</td></tr>"
                addThis += tablerow;

            }

            $("#rankTable").html(addThis);

        },

        error: function (jqHXR, statusText, errorThrown) {
            $("#rightDiv").html("Something went wrong\n" + statusText + "\n" + errorThrown);
        }
    });


    $.ajax({
        url: "/Api/GetPawns",
        dataType: 'json',
        data: {},
        success: function (data) {
            
            var addThis = "<tr><th>Type</th><th>Hp</th></tr>"
            
            for (var i = 0; i < data.length; i++) {

                var tablerow = "<tr><td>" + data[i].Type + "</td><td>" + data[i].Hp + "</td></tr>"
                addThis += tablerow;

            }

            $("#pawnTable").html(addThis);

        },
        error: function (jqHXR, statusText, errorThrown) {
            $("#pawnsList").html("Not working!\n" + statusText + "\n" + errorThrown);
        }
    });


});