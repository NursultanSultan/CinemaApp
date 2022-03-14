

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
                items: 1
            },
            600: {
                items: 2
            },
            1000: {
                items: 3
            }
        }
        
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


    $(".card__add").click(function () {

        var MvId = $(this).parent().data("id");

        console.log("movie :" + MvId);

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

    $(".comment__form").submit(function (e) {
        e.preventDefault();

        var MvId = document.querySelector(".comments").getAttribute("data-id");
        var comment_content = document.querySelector(".form__textarea").value;
        console.log("movie :" + MvId);
        console.log("comment :" + comment_content);

        var commentlist = document.querySelector("#comment__list");
        console.log("comment list:" + commentlist);

        

        $.ajax({
            type: "POST",
            url: "/Movie/CommentAdd",
            data: {
                "movieId": MvId,
                "content": comment_content
            },
            success: function (response) {
                console.log(response);
                //commentlist.innerHTML = "";
                commentlist.innerHTML += response;
                
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });

    //$(".comment__delete__form").submit(function (e) {

    //    e.preventDefault();

    //    var commentId = $(this).parent().data("id");

    //    console.log("comment id:" + commentId);

    //    $.ajax({
    //        type: "POST",
    //        url: /Movie/CommentDelete,
    //        data: {
    //            "commentId": commentId
    //        },
    //        success: function (response) {
    //            //Movies.innerHTML = "";
    //            //Movies.innerHTML = response;
    //            console.log(response);
    //        },
    //        failure: function (response) {
    //            alert(response.responseText);
    //        },
    //        error: function (response) {
    //            alert(response.responseText);
    //        }
    //    });
    //});

});





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







