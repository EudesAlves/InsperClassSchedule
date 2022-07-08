// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $(function () {
        $('.time').dateAndTime();
    });


    $("#slcCourse").change(function () {
        var courseId = this.value;
        console.log(courseId);

        if (courseId > 0) {
            LoadClass(courseId);
        }
        else {
            var slcClass = $("#slcClass");
            slcClass.children().remove().end().append('<option value="0">Selecione</option>');
        }
    });

    function LoadClass(courseId) {
        $.ajax({
            url: '/Schedule/GetClassesByCourseId?id=' + courseId,
            type: 'GET',
            dataType: 'json',
            success: function (response) {

                var slcClass = $("#slcClass");
                FillSelect(response, slcClass);
            }
        });
    }

    function FillSelect(response, selectField) {
        selectField.children().remove().end().append('<option value="0">Selecione</option>');
        $(response).each(function () {
            var option = $("<option />");
            option.html(this.name);
            option.val(this.id);
            selectField.append(option);
        });
    }
});
