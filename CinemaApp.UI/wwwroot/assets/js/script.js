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

// var btns = document.querySelectorAll(".btn");
//    Array.from(btns).forEach(item => {
//       item.addEventListener("click", () => {
//          var selected = document.getElementsByClassName('tab_header active');
//          console.log(selected[0]);
//          selected[0].classList.remove("active");
         
//          item.classList.add("active");
//       });
//    });

// var selector = '.tab_header a';
// var lists = '.tab_body';

// $(selector).on('click', function(){
//     $(selector).removeClass('active');
//     $(this).addClass('active');


// });


var tab_header = document.querySelectorAll(".btn");
var tab_content = document.querySelectorAll(".tab_list");

for (let i = 0; i < tab_header.length; i++) {
 
    tab_header[i].addEventListener("click", () => {
        tab_content.forEach((item) => {
        
        item.classList.add("tab_display");
      });
      tab_header.forEach((item) => {
        
        item.classList.remove("active");
      });
      tab_content[i].classList.remove("tab_display");
      tab_header[i].classList.add("active");
    });
  }
