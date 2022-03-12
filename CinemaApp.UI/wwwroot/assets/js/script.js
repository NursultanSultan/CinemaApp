$('.header__btn').on('click', function () {
    $(this).toggleClass('header__btn--active');
    $('.header__nav').toggleClass('header__nav--active');
    $('.body').toggleClass('body--active');
});

$('.header__search-btn, .header__search-close').on('click', function () {
    $('.header__search').toggleClass('header__search--active');
});

$(document).ready(function () {
    $("#testimonial-slider").owlCarousel({
        
        itemsDesktop: [1000, 3],
        itemsDesktopSmall: [980, 2],
        itemsTablet: [768, 2],
        itemsMobile: [650, 1],
        pagination: true,
        navigation: false,
        slideSpeed: 1000,
        autoPlay: true,
        responsive: {
            0: {
                items: 1
            },
            400: {
                items: 2
            },
            600: {
                items: 3
            },
            1000: {
                items: 5
            }
        }
        
    });
});



$('#hero_owl').owlCarousel({
    loop: true,
    margin: 10,
    nav: false,
    smartSpeed: 500,
    autoplay: true,
    autoplayTimeout: 3000,
    responsive: {
        0: {
            items: 1
        },
        400: {
            items: 2
        },
        600: {
            items: 3
        },
        1000: {
            items: 5
        }
    }
})

//var tab_header = document.querySelectorAll(".btn");
//var tab_content = document.querySelectorAll(".tab_list");

//for (let i = 0; i < tab_header.length; i++) {
 
//    tab_header[i].addEventListener("click", () => {
//        tab_content.forEach((item) => {
        
//        item.classList.add("tab_display");
//      });
//      tab_header.forEach((item) => {
        
//        item.classList.remove("active");
//      });
//        console.log(i);
//     /* tab_content[i].classList.remove("tab_display");*/
//      /*tab_header[i].classList.add("active");*/
//    });
//  }


//$(document).ready(function () {

//    $("#SelectCinemas").change(function () {
//        var CinemaId = $(this).val();
//        console.log(CinemaId);
//        var Movies = document.querySelector("#Movies")

//        $.ajax({
//            type: "GET",
//            url: "/Home/GetFilterMovie",
//            data: {
//                "CineId": CinemaId == 'all' ? null : CinemaId
//            },
//            success: function (response) {
//                Movies.innerHTML = "";
//                Movies.innerHTML = response;
//            },
//            failure: function (response) {
//                alert(response.responseText);
//            },
//            error: function (response) {
//                alert(response.responseText);
//            }
//        });
//    });
//});

$(document).ready(function () {


    $("#filter").click(function () {

        var CinemaId = $("#SelectCinemas").val();
        var LanguageId = $("#SelectLanguages").val();

        console.log("cine :" + CinemaId);
        console.log("lang :" + LanguageId);

        var Movies = document.querySelector("#Movies")

        $.ajax({
            type: "GET",
            url: "/Home/GetFilterMovie",
            data: {
                "CineId": CinemaId == 'all' ? null : CinemaId,
                "LangId": LanguageId == 'all' ? null : LanguageId
            },
            success: function (response) {
                Movies.innerHTML = "";
                Movies.innerHTML = response;
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });

    
});


$(document).ready(function () {


    $(".card__add").click(function () {

        var MvId = $(this).parent().data("id");

        console.log("movie :" + MvId);

        //var Movies = document.querySelector("#Movies")

        $.ajax({
            type: "GET",
            url: `/Favorite/AddFavorite?movieId=${MvId}`,
            //data: {
            //    "movieId":+MvId
            //},
            success: function (response) {
                //Movies.innerHTML = "";
                //Movies.innerHTML = response;
                console.log(response);
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });


});