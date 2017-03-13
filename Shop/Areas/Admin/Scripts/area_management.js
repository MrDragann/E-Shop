
/* Заказы */
$(document).ready(function(){
    $('#reloadOrders').click(function () {
        var updateOrdersHref = $(this).attr("data-toggle");
        updateOrders(updateOrdersHref);
    });
    function updateOrders(href) {
        $('#Orders').load(href);

    };


/* Категории */
$(document).ready(function () {
    $('#reloadCategories').click(function () {
        UpdateCategories();
    });

    $('#AddMainCategory').click(function () {
        var data = {
            name: $('#MainCategory').val()
        }

        $.ajax({
            type: "POST",
            url: 'AddMainCategory',

            data: data,
            success: function (result) {
                console.log(result);
                UpdateCategories();
            },
            error: function (xhr) {
                console.log(xhr.responseText);
            }
        });
    });

    $('#AddChildCategory').click(function () {
        var select = $('#MainCategories');
        var SelectedMainCategory = $(':selected', select);

        var data = {
            mainId: SelectedMainCategory.val(),
            child: $('#ChildCategory').val()
        }

        $.ajax({
            type: "POST",
            url: 'AddChildCategory',

            data: data,
            success: function (result) {
                console.log(result);
                UpdateCategories();
            },
            error: function (xhr) {
                console.log(xhr.responseText);
            }
        });
    });

    $('#EditMainCategory').click(function () {
        var select = $('#EdMainCategories');
        var SelectedMainCategory = $(':selected', select);

        var data = {
            mainId: SelectedMainCategory.val(),
            newName: $('#NewMainCategory').val()
        }

        $.ajax({
            type: "POST",
            url: 'EditMainCategory',

            data: data,
            success: function (result) {
                console.log(result);
                UpdateCategories();
            },
            error: function (xhr) {
                console.log(xhr.responseText);
            }
        });
    });

    $('#EditChildCategory').click(function () {
        var select = $('#EdChildCategories');
        var SelectedMainCategory = $(':selected', select);

        var data = {
            childId: SelectedMainCategory.val(),
            newName: $('#NewChildCategory').val()
        }

        $.ajax({
            type: "POST",
            url: 'EditChildCategory',

            data: data,
            success: function (result) {
                console.log(result);
                UpdateCategories();
            },
            error: function (xhr) {
                console.log(xhr.responseText);
            }
        });
    });

    $('#DeleteMainCategory').click(function () {
        var select = $('#DelMainCategories');
        var SelectedMainCategory = $(':selected', select);

        var data = {
            mainId: SelectedMainCategory.val()
        }

        $.ajax({
            type: "POST",
            url: 'DeleteMainCategory',

            data: data,
            success: function (result) {
                console.log(result);
                UpdateCategories();
            },
            error: function (xhr) {
                console.log(xhr.responseText);
            }
        });
    });

    $('#DeleteChildCategory').click(function () {
        var select = $('#DelChildCategories');
        var SelectedMainCategory = $(':selected', select);

        var data = {
            childId: SelectedMainCategory.val()
        }

        $.ajax({
            type: "POST",
            url: 'DeleteChildCategory',

            data: data,
            success: function (result) {
                console.log(result);
                UpdateCategories();
            },
            error: function (xhr) {
                console.log(xhr.responseText);
            }
        });
    });

    function UpdateCategories() {
        $('#Categories').load("http://localhost:58081/Admin/Admin/upCategories");
    }
});

});