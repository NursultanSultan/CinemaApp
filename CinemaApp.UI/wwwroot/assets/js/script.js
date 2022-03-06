var navItem = document.getElementsByClassName("nav-link");
window.addEventListener("scroll", () => {
    if(document.body.scrollTop > 70 || document.documentElement.scrollTop > 70) {
        
        // header.style.backgroundColor="#222222";
        header.style.opacity="0.9";
        
        // headerLogo.style.width="140px";
    }else {
        
        header.style.backgroundColor="black";
        header.style.opacity="0.7";
        // headerLogo.style.width="200px";
    }
})


$(document).ready(function () {
    $("#testimonial-slider").owlCarousel({
        items: 3,
        itemsDesktop: [1000, 3],
        itemsDesktopSmall: [980, 2],
        itemsTablet: [768, 2],
        itemsMobile: [650, 1],
        pagination: true,
        navigation: false,
        slideSpeed: 1000,
        autoPlay: true
    });
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