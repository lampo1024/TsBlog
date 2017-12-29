$.validator.applyBootstrap = function () {
  $.validator.setDefaults({
    highlight: function (element) {
      $(element).addClass('has-error');
      $(element).removeClass('valid');
      $(element).closest('.input-group').addClass('has-error');
      $(element).closest('.input-group').removeClass('valid');
    },
    unhighlight: function (element) {
      $(element).closest("div,span,form").find("span.inp-validation-icon").tooltip('hide');
      $(element).closest("div,span,form").find("span.inp-validation-icon").tooltip('destroy');
      $(element).closest("div,span,form").find("span.inp-validation-icon").remove();
      $(element).addClass('valid');
      $(element).removeClass('has-error');
      $(element).closest('.input-group').addClass('valid');
      $(element).closest('.input-group').removeClass('has-error');
    },
    showErrors: function (errorMap, errorList) {
      this.defaultShowErrors();
      $.each(this.errorList, function (idx, item) {
        var elm = $(item.element);
        elm.closest("div,span,form").find("span.inp-validation-icon").tooltip('hide');
        elm.closest("div,span,form").find("span.inp-validation-icon").tooltip('destroy');
        elm.closest("div,span,form").find("span.inp-validation-icon").remove();
        var errIco = $("<span class='inp-validation-icon glyphicon glyphicon-exclamation-sign'></span>").attr("title", htmlEncode(item.message));
        errIco.insertAfter(elm);
        errIco.tooltip({ placement: 'right', trigger: 'manual', container: 'body' });
        errIco.tooltip('show');
        $(window).on('resize', function () {
          errIco.tooltip('show');
        })
      });
    }
  });
}

