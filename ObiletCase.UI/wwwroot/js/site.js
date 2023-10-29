var date = new Date();
var PageFunctions = {
    init: function () {
        PageFunctions.DateChange();
        PageFunctions.SelectPickerLoad();
        PageFunctions.SelectPickerChange();
        PageFunctions.OriginSearch();
        PageFunctions.DestinationSearch();
        PageFunctions.DatePickerLoad();
        PageFunctions.LocationExchange();
        PageFunctions.localStorageSet();
        PageFunctions.localStorageGet();
        PageFunctions.GoBack();
    },
    DateChange: function () {
        $('#today').on('click', function () {

            $('.datepicker').datepicker('setDate', date);
        });
        $('#tomorrow').on('click', function () {
            $('.datepicker').datepicker('setDate', new Date(date.getFullYear(), date.getMonth(), (date.getDate() + 1)));
        });
    },
    SelectPickerLoad: function () {
        $('.origin').selectpicker({
            liveSearch: true
        });

        $('.destination').selectpicker({
            liveSearch: true
        });
    },
    SelectPickerChange: function () {

        $('.selectpicker').on('change', function () {
            var origin = $("#origin").val();
            var destination = $("#destination").val();

            if (origin === destination) {
                alert("Kalkış ve varış noktası aynı olamaz!");
                $('#TicketFind').attr('disabled', 'disabled');
            }
            else {
                $('#TicketFind').removeAttr('disabled');
            }
        });
    },
    OriginSearch: function () {
        $(".origin .bs-searchbox input").on('keyup', function () {
            var search = $(this).val();
            console.log(search);

            $.ajax({
                url: 'Journey/BusLocationListSearch',
                type: 'POST',
                dataType: 'json',
                data: { 'Search': search },
                success: function (data) {
                    console.log(data);

                    var originSelect = $("#origin");
                    originSelect.empty();
                    originSelect.selectpicker('destroy');
                    originSelect.selectpicker('refresh');

                    createOptionList(data);
                    $('#origin').selectpicker('refresh');
                }
            });
        });
    },
    DestinationSearch: function () {
        $(".destination .bs-searchbox input").on('keyup', function () {
            var search = $(this).val();
            console.log(search);

            $.ajax({
                url: 'Journey/BusLocationListSearch',
                type: 'POST',
                dataType: 'json',
                data: { 'Search': search },
                success: function (data) {
                    console.log(data);

                    var destinationSelect = $("#destination");
                    destinationSelect.empty();
                    destinationSelect.selectpicker('destroy');
                    destinationSelect.selectpicker('refresh');

                    createOptionList(data);
                    $('#destination').selectpicker('refresh');
                }
            });
        });
    },
    DatePickerLoad: function () {

        $('.datepicker').datepicker({
            clearBtn: false,
            format: "dd.mm.yyyy",
            startDate: new Date()
        });
    },
    LocationExchange: function () {
        $("#locationExchange").click(function () {
            var originValue = $("#origin").val();
            var destinationValue = $("#destination").val();

            $("#origin").selectpicker('val', destinationValue);
            $("#destination").selectpicker('val', originValue);
        });
    },
    localStorageSet: function () {
        $("#TicketFind").on("click", function () {
            localStorage.clear();
            var originId = $("#origin").val();
            var destinationId = $("#destination").val();
            var date = $("#reservationDate").val();

            localStorage.setItem("OriginId", originId);
            localStorage.setItem("DestinationId", destinationId);
            localStorage.setItem("Date", date);
        });
    },
    localStorageGet: function () {
        var originValue = localStorage.getItem("OriginId");
        var destinationValue = localStorage.getItem("DestinationId");
        var dateValue = localStorage.getItem("Date");

        $("#origin").selectpicker('val', originValue);
        $("#destination").selectpicker('val', destinationValue);
        
        if (dateValue == null) {
            $('.datepicker').datepicker('setDate', new Date(date.getFullYear(), date.getMonth(), (date.getDate() + 1)));
        }
        else {
            $('.datepicker').datepicker('setDate', dateValue);
        }

    },
    GoBack: function () {
        $("#goBackButton").on("click", function () {
            window.location.href = "/Journey/Index";
        });
    }
};
function createOptionList(data) {
    $.each(data, function (i, item) {
        $('#origin').append($('<option>', { 
            value: item.id,
            text : item.name 
        }));
    });
}
$(document).ready(function () {
    PageFunctions.init();
});
