// Write your Javascript code.
///////////////////////////// for comments part of the blog
var currentComment = 0;
var newComment = 0;
var textComment;
var canEdit = true;

// replace text with textarea
$(".comment").on('click', function () {
    newComment = $(this).attr("id");
    if (newComment === currentComment && !canEdit)
        return;

    if (currentComment !== 0) {
        $("p[id =" + currentComment + "]").text(textComment);
    }

    currentComment = newComment;
    canEdit = false;
    textComment = $(this).text();
    $(this).html("<textarea id=\"commentPlaceholder\" class=\"form-control\">" +
                       textComment + "</textarea><br/>" +
                      "<button id=\"commentEdit\" class=\"btn btn-primary\">Save</button>");
});

// asynch post - send data to server side and display callback information
$(document).on('click', '#commentEdit', function () {
    $.post("../../Comment/Edit",
       {
           id: currentComment,
           text: $("#commentPlaceholder").val()
       },
       function (data) {
           $("p[id =" + currentComment + "]").text(data);
           textComment = data;
           canEdit = true;
       });


    // both of these async method works but I prefer fist one :)
    /*           $.ajax(  
               {
                   type: "POST", //HTTP POST Method  
                   url: "../../Comment/Edit", // Controller/View   
                   data: { //Passing data  
                           id: currentComment,
                           text: $("#commentPlaceholder").val()
                         },
                   success: function (data) {
                                jQuery("p[id =" + currentComment + "]").text(data);
                                textComment = data;
                                canEdit = true;
                            }
               }); */

});

///////////////////////////// for comments part of the blog


// do like and dislike
var like = $("#like").data("like");

if (like == "True") {
    like = true;
    $('#like').css('color', 'dodgerblue');
}
else {
    like = false;
    $('#like').css('color', '');
}

var dislike = $("#dislike").data("dislike");
if (dislike == "True") {
    dislike = true;
    $('#dislike').css('color', 'black');
}
else {
    dislike = false;
    $('#dislike').css('color', '');
}

// like - dislike functionality

$("#like").on('click', function () {
    if (!like) {
        like = true;
        dislike = false;
        $.post("../../Blog/Like",
        {
            id: $('#BlogId').val(),
            status: true
        },
        function (data) {
                $('#like').css('color', 'dodgerblue');
                $('#dislike').css('color', '');
                var arr = data.split('/');
                $('#numberOfLike').text(arr[0]);
                $('#numberOfDislike').text(arr[1]);
        });
    }
    else {
        like = false;
        $.post("../../Blog/Like",
           {
               id: $('#BlogId').val(),
               status: false
           },
           function (data) {
               $('#like').css('color', '');
               var arr = data.split('/');
               $('#numberOfLike').text(arr[0]);
               $('#numberOfDislike').text(arr[1]);
           }); 
    }
});

$("#dislike").on('click', function () {
    if (!dislike) {
        like = false;
        dislike = true;

        $.post("../../Blog/Dislike",
        {
            id: $('#BlogId').val(),
            status: true
        },
        function (data) {
            $('#dislike').css('color', 'black');
            $('#like').css('color', '');
            var arr = data.split('/');
            $('#numberOfLike').text(arr[0]);
            $('#numberOfDislike').text(arr[1]);
        });


    }
    else {
        dislike = false;
        $.post("../../Blog/dislike",
           {
               id: $('#BlogId').val(),
               status: false
           },
           function (data) {
               $('#dislike').css('color', '');
               var arr = data.split('/');
               $('#numberOfLike').text(arr[0]);
               $('#numberOfDislike').text(arr[1]);
           });
    }
});

$(function () {
    $('[data-toggle="popover"]').popover()
});

////////////// go to top button ///////////////////////

var offset = 300;
var duration = 500;
jQuery(window).scroll(function () {
    if (jQuery(this).scrollTop() > offset) {
        jQuery('.back-to-top').fadeIn(duration);
    } else {
        jQuery('.back-to-top').fadeOut(duration);
    }
});

jQuery('.back-to-top').click(function (event) {
    event.preventDefault();
    jQuery('html, body').animate({ scrollTop: 0 }, duration);
    return false;
});

/////////////////////////////////////


//////////about collaplse expand  /////////////////
jQuery(".panel-heading").click(function(){
    $(this).parent().children(".panel-body").slideToggle("slow");
}); 


//////// end collaplse expand  ///////////////


