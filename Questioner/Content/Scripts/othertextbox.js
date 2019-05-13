$(document).ready(function () {
    $("#otherTextBox").hide();
    $("input[type=checkbox]").prop('checked', false);

    $('#otherCheckBox').click(function () {
        if (this.checked == true) {
            $("#otherTextBox").show();
            $("input[Name=SelectedOptions]").prop('checked', false);
            $("input[Name=SelectedOptions]").attr('disabled', true);
        }
        else {
            $("#otherTextBox").hide();
            $("input[Name=SelectedOptions]").attr('disabled', false);
        }
    });
});