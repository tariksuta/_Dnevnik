//$(document).ready(function(){//kada se učita dokument, potrebno je da se ovo aktivira nad buttonima i formama,
//    //međutim, svi koji se naknadno učitavaju ajaxom neće imati ove evente na sebi, pa moramo nakon što se izvrši bilo kakad poziv ponovo
//    //dodavati evente
//    $("button[ajax-poziv='da']").click(function(event) {
//        var btn = $(this);
//        var url = btn.attr("ajax-url");
//        var rez = btn.attr("ajax-rezultat");

//        $.get(url, function(rezultat, status) {
//            $("#" + rez).html(rezultat);
//        });
//    });

//    $("form[ajax-poziv='da']").submit(function(event) {
//        event.preventDefault();

//        var forma = $(this);
//        var url = forma.attr("action");
//        var rez = forma.attr("ajax-rezultat");

//        $.ajax(
//            {
//                type="POST",
//                url=url,
//                data=forma.serialize(),
//                success: function(rezultat) {
//                    $("#" + rez).html(rezultat);
//                }
//            }
//        );
//    });

//});

function DodajAjaxEvente() {

    $("button[ajax-poziv='da']").click(function (event) {
        var btn = $(this);
        var url = btn.attr("ajax-url");
        var r = btn.attr("ajax-rezultat");
        $.get(url, function (rezultat, status) {
            $("#" + r).html(rezultat);
        });
    });

    $("form[ajax-poziv='da']").submit(function (event) {
        event.preventDefault();

        var forma = $(this);
        var URL = forma.attr("action");
        var rez = forma.attr("ajax-rezultat");

        $.ajax(
            {
                type="POST",
                url=URL,
                data=forma.serialize(),
                success: function (rezultat) {
                    $("#" + rez).html(rezultat);
                }
            }
        );
    });
}

$(document).ready(function() {
    DodajAjaxEvente();
});

$(document).ajaxComplete(function() {
    DodajAjaxEvente();
});