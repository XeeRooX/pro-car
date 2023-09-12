function main() {
    $(document.body).on('click', "#load-cars-btn", LoadBtnClick);
}


function LoadBtnClick() {
    var brandId = getUrlParameter("brand");
    var cartypeId = getUrlParameter("cartype");

    var brandIdNum = Number(brandId);
    var cartypeIdNum = Number(cartypeId);

    if (!isInteger(brandId)) {
        brandIdNum = 0;
    }

    if (!isInteger(cartypeId)) {
        cartypeIdNum = 0;
    }

    var countLoaded = $('.car-card').length;

    var input = {
        "brandId": brandIdNum,
        "carTypeId": cartypeIdNum,
        "CountLoadedCars":countLoaded
    };

    $.ajax({
        url: "/api/cars",
        type: "POST",
        data: JSON.stringify(input),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            PrintCars(data);
        }
})
}

function PrintCars(input) {

    for (var i = 0; i < input.cars.length; i++) {
        foreach(input.cars[i]);
    }

    function foreach(data) {
        var temp = $(".car-card").first().clone();

        temp.find(".car-link").attr('href', `/Cars/View/${data.id}`);
        temp.find(".car-title").text(`${data.brand} ${data.model}`);
        temp.find(".img-cart").attr('src', `/cars/${data.id}/1.png`)
        temp.find(".car-price").text(`${data.costPerDay} `);
        temp.find(".car-gearbox").text(`${data.gearboxType}`);
        temp.find(".car-year").text(`${data.yearOfIssue}`);

        $('.product-lists').append(temp);
    }

    if (input.isLastPage) {
        $('#load-cars-btn').addClass('d-none');
    }
}

function getUrlParameter(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function isInteger(value) {
    return /^\d+$/.test(value);
}

main();
