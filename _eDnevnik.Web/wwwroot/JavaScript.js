function DodajAjaxEvente() {

    $("button[ajax-poziv='da']").click(function (event) {

        var btn = $(this);
        var url = btn.attr("ajax-url");
        var rez = btn.attr("ajax-rezultat");

        $.get(url,
            function (rezultat, status) {
                $("#" + rez).html(rezultat);
            });

    });

    //$("form[ajax-poziv='da']").submit(function (event) {//na klik na dugme sa id submit

    //    event.preventDefault();//spriječavamo reload stranice, tj. izvršavanj difoltne akcije na submit bez ajaxa

    //    var forma = $(this);
    //    var URL = forma.attr("action");
    //    var rez = forma.attr("ajax-rezultat");
    //    $.ajax(
    //        {
    //            type: "POST",//metod
    //            url: URL,//action
    //            data: forma.serialize(),//sta ce se poslati, serialize -> sadrzaj forme pretvara u parametar data
    //            success: function (rezultat) {//po završetku
    //                $("#" + rez).html(rezultat);
    //            }
    //        }
    //    );
    //});

}

$(document).ready(function () {
    DodajAjaxEvente();
});

$(document).ajaxComplete(function () {
    DodajAjaxEvente();
});