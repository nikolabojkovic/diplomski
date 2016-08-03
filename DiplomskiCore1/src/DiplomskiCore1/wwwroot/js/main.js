jQuery(function($) {'use strict',

	//#main-slider
	$(function(){
		$('#main-slider.carousel').carousel({
			interval: 8000
		});
	});


	// accordian
	$('.accordion-toggle').on('click', function(){
		$(this).closest('.panel-group').children().each(function(){
		$(this).find('>.panel-heading').removeClass('active');
		 });

	 	$(this).closest('.panel-heading').toggleClass('active');
	});

	//Initiat WOW JS
	new WOW().init();

	// portfolio filter
	$(window).load(function(){'use strict';
		var $portfolio_selectors = $('.portfolio-filter >li>a');
		var $portfolio = $('.portfolio-items');
		$portfolio.isotope({
			itemSelector : '.portfolio-item',
			layoutMode : 'fitRows'
		});
		
		$portfolio_selectors.on('click', function(){
			$portfolio_selectors.removeClass('active');
			$(this).addClass('active');
			var selector = $(this).attr('data-filter');
			$portfolio.isotope({ filter: selector });
			return false;
		});
	});

	// Contact form
	var form = $('#main-contact-form');
	form.submit(function(event){
		event.preventDefault();
		var form_status = $('<div class="form_status"></div>');
		$.ajax({
			url: $(this).attr('action'),

			beforeSend: function(){
				form.prepend( form_status.html('<p><i class="fa fa-spinner fa-spin"></i> Email is sending...</p>').fadeIn() );
			}
		}).done(function(data){
			form_status.html('<p class="text-success">' + data.message + '</p>').delay(3000).fadeOut();
		});
	});

	
	//goto top
	$('.gototop').click(function(event) {
		event.preventDefault();
		$('html, body').animate({
			scrollTop: $("body").offset().top
		}, 500);
	});	

	//Pretty Photo
	$("a[rel^='prettyPhoto']").prettyPhoto({
		social_tools: false
	});


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

});