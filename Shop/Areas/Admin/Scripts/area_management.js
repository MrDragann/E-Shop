$(document).ready(function () {
    
});

/* Товары */
//Обновление данных по товарам
$('#reloadProducts').click(function () {
    updateProducts();
});
//Добавление нового товара
$('#AddProduct').click(function () {

    var files = document.getElementById('ProductImage').files;
    var formData = new FormData();
    formData.append("file", files[0]);
    formData.append("Name", $('#ProductName').val());
    formData.append("Price", $('#ProductPrice').val());
    formData.append("Description", $('#ProductDescription').val());
    formData.append("Characteristics", $('#ProductCharacteristics').val());
    formData.append("Tags", $('#ProductTags').val());
    formData.append("DateAdd", $('#ProductDateAdd').val());
    formData.append("CategoryId", $('#ProductCategory').val());
    formData.append("ManufacturerId", $('#ProductManufacturer').val());

    $.ajax({
        type: "POST",
        url: '/Products/AddProduct',
        contentType: false,
        processData: false,
        data: formData,
        success: function (result) {
            console.log(result);
            //updateProducts();
        },
        error: function (xhr) {
            console.log(xhr.responseText);
        }
    });
});
    $(document).ready(function () {

        
    });


    //Удаление товара
    function deleteProduct(id) {
        var formaData = new FormData();

        formaData.append("productId", id);

        $.ajax({
            url: '/Products/DeleteProducts',
            type: 'post',
            contentType: false,
            processData: false,
            data: formaData,
            beforeSend: function () { console.log(id); },
            success: function (data) {
                console.log(data);
                updateProducts();
            }
        });

    }
    //Обноновление таблицы товаров
    function updateProducts() {
        $('#Products').load("/Admin/Products/AjaxProducts");
    }
    //Редактирование товара
    $('button.EditProductId').click(function () {
        var EddProductId = $(this).val();

        $('#EditModalContent').load("/Admin/Products/EditProduct/" + EddProductId);

    });
    /* Редактирование товара */
    $('#EditProduct').click(function () {
        var files = document.getElementById('EdProductImage').files;
        var formData = new FormData();

        formData.append("file", files[0]);
        formData.append("Id", $('#ProductId').val());
        formData.append("Name", $('#EdProductName').val());
        formData.append("Price", $('#EdProductPrice').val());
        formData.append("Description", $('#EdProductDescription').val());
        formData.append("Characteristics", $('#EdProductCharacteristics').val());
        formData.append("Tags", $('#EdProductTags').val());
        formData.append("DateAdd", $('#EdProductDateAdd').val());
        formData.append("CategoryId", $('#EdProductCategory').val());
        formData.append("ManufacturerId", $('#EdProductManufacturer').val());

        $.ajax({
            type: "POST",
            url: '/Products/EditProduct',
            contentType: false,
            processData: false,
            data: formData,
            success: function (result) {
                console.log(result);
            },
            error: function (xhr) {
                console.log(xhr.responseText);
            }
        });

    });
/* Заказы */
$('#reloadOrders').click(function () {
    var updateOrdersHref = $(this).attr("data-toggle");
    updateOrders(updateOrdersHref);
});
function updateOrders(href) {
    $('#Orders').load(href);
}

/* Категории */
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