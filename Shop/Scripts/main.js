/*price range*/

 $('#sl2').slider();

	var RGBChange = function() {
	  $('#RGB').css('background', 'rgb('+r.getValue()+','+g.getValue()+','+b.getValue()+')')
	};	
		
/*scroll to top*/

$(document).ready(function(){
	$(function () {
		$.scrollUp({
	        scrollName: 'scrollUp', // Element ID
	        scrollDistance: 300, // Distance from top/bottom before showing element (px)
	        scrollFrom: 'top', // 'top' or 'bottom'
	        scrollSpeed: 300, // Speed back to top (ms)
	        easingType: 'linear', // Scroll to top easing (see http://easings.net/)
	        animation: 'fade', // Fade, slide, none
	        animationSpeed: 200, // Animation in speed (ms)
	        scrollTrigger: false, // Set a custom triggering element. Can be an HTML string or jQuery object
					//scrollTarget: false, // Set a custom target element for scrolling to the top
	        scrollText: '<i class="fa fa-angle-up"></i>', // Text for element, can contain HTML
	        scrollTitle: false, // Set a custom <a> title if required.
	        scrollImg: false, // Set true to use image
	        activeOverlay: false, // Set CSS color to display scrollUp active point, e.g '#00FFFF'
	        zIndex: 2147483647 // Z-Index for the overlay
		});
	});
});

/* Корзина */

$(document).ready(function () {
    $('a.add-to-cart').click(function () {
        var productId = $(this).attr("id").substr(10);
        var Quantity = $('input#productQuantity_' + productId).val();
        if (Quantity == undefined) Quantity = 1;

        var formData = new FormData();

        formData.append("productId", productId);
        formData.append("Quantity", Quantity);

        $.ajax({
            type: "POST",
            url: '/Order/AddToCart',
            contentType: false,
            processData: false,
            data: formData,
            success: function (result) {
                console.log(result);
                $('#AddToCart').modal(Option);
                UpdateCartStatus();
            },
            error: function (xhr) {
                console.log(xhr.responseText);
            }
        });
    });
    function UpdateCartStatus() {
        var href = $('#LoginPartial').attr('data-href');
        $('#LoginPartial').load(href);
    }
});
