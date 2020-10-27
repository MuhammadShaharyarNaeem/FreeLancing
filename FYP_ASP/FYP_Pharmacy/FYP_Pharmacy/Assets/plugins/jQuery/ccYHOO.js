/*
* Created By Shemeer NS 
* This Code is created for demo purpose and uploaded in Codeproject
* My Other Articles in codeproject - http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid=3175840
* */
$(document).ready(function () {
    $('#submit').click(function () {
        var errormsg = "";
        var amount = $('#txtAmount').val();
        var from = $('#drpFrom').val();
        var to = $('#drpTo').val();
        $.ajax({ type: "POST",
            url: "http://localhost:56053/webservice/CurrencyConvertor.asmx",
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
                    errormsg = 'Not connect.\n Verify Network.'; ;
                } else if (jqXHR.status == 404) {
                    errormsg = 'Requested page not found. [404]'; ;
                } else if (jqXHR.status == 500) {
                    errormsg = 'Internal Server Error [500].'; ;
                } else if (exception === 'parsererror') {
                    errormsg = 'Requested JSON parse failed.'; ;
                } else if (exception === 'timeout') {
                    errormsg = 'Time out error.'; ;
                } else if (exception === 'abort') {
                    errormsg = 'Ajax request aborted.'; ;
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
