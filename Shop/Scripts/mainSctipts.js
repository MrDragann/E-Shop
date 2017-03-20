
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

    function EditQuantity(productId, Quantity) {

        var formData = new FormData();

        formData.append("productId", productId);
        formData.append("Quantity", Quantity);

        $.ajax({
            type: "POST",
            url: '/Order/EditQuantity',
            contentType: false,
            processData: false,
            data: formData,
            success: function (result) {
                console.log(result);
                UpdateCart();
            },
            error: function (xhr) {
                console.log(xhr.responseText);
            }
        });
    }

    $('input.Quantity').change(function () {
        //alert($(this).val());
        var productId = $(this).attr("id").substr(9);
        var Quantity = $(this).val();
        EditQuantity(productId, Quantity);
        UpdateCart();

    });

    $('button.QuantityDown').click(function () {
        var ItemId = $(this).attr("id").substr(13);
        var ItemQuantity = $('input#Quantity_' + ItemId);
        var ItemQuantityValue = ItemQuantity.val();
        if (ItemQuantityValue > 1) {
            var NewQuantity = parseInt(ItemQuantityValue) - 1;
            ItemQuantity.val(NewQuantity);
            EditQuantity(ItemId, NewQuantity);
            UpdateCart();
        }

    });

    $('button.QuantityUp').click(function () {
        var ItemId = $(this).attr("id").substr(11);
        var ItemQuantity = $('input#Quantity_' + ItemId);
        var ItemQuantityValue = ItemQuantity.val();
        if (ItemQuantityValue < 30) {
            var NewQuantity = parseInt(ItemQuantityValue) + 1;
            ItemQuantity.val(NewQuantity);
            EditQuantity(ItemId, NewQuantity);
            UpdateCart();
        }

    });

    $('button.cart_quantity_delete').click(function () {
        var productId = $(this).attr("id").substr(15);

        var formData = new FormData();

        formData.append("productId", productId);

        $.ajax({
            type: "POST",
            url: '/Order/RemoveFromCart',
            contentType: false,
            processData: false,
            data: formData,
            success: function (result) {
                console.log(result);
                UpdateCart();
            },
            error: function (xhr) {
                console.log(xhr.responseText);
            }
        });
    });
    function UpdateCart() {
        var href = $('#cart_items').attr('data-href');
        $('#cart_items').load(href);
    }
});


