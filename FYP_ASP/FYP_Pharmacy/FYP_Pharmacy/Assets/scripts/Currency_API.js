$(document).ready(function () {
    $('#submit').click(function () {
        var errormsg = "";
        var amount = $('#txtAmount').val();
        var from = $('#drpFrom').val();
        var to = $('#drpTo').val();
        $.ajax({
            type: "POST",
            url: "WebService.asmx/ConvertGOOG",
            data: "{amount:" + amount + ",fromCurrency:'" + from + "',toCurrency:'" + to + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: function () {
                $('#results').html("Converting...");
            },
            success: function (data) {
                $('#results').html(amount + ' ' + from + '=' + data.d.toFixed(2) + ' ' + to);
            },
            error: function (jqXHR, exception) {
                if (jqXHR.status === 0) {
                    errormsg = 'Not connect.\n Verify Network.';;
                } else if (jqXHR.status == 404) {
                    errormsg = 'Requested page not found. [404]';;
                } else if (jqXHR.status == 500) {
                    errormsg = 'Internal Server Error [500].';;
                } else if (exception === 'parsererror') {
                    errormsg = 'Requested JSON parse failed.';;
                } else if (exception === 'timeout') {
                    errormsg = 'Time out error.';;
                } else if (exception === 'abort') {
                    errormsg = 'Ajax request aborted.';;
                } else {
                    errormsg = 'Uncaught Error.';
                }
                $('#results').html(errormsg);
                $('<a href="#" >Click here for more details</a>').click(function () {
                    alert(jqXHR.responseText);
                }).appendTo('#results');
            }
        });
    });
});