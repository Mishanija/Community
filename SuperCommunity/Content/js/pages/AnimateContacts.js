function animateContacts(iconSize) {

    var animates = $('.menuAnimate');

    animates.each(function() {
        var id = $(this).attr('id');
        var spans = $('#' + id + ' > div > span');
        var blocks = $('#' + id + ' > div');
        var boxImage = $('#' + id + ' > img.box');
        spans.hide();
        var left = ([]);
        var bottom = ([]);

        blocks.each(function(n) {
            left[n] = $(this).css('left');
            bottom[n] = $(this).css('bottom');
        });

        var boxImageHeight = boxImage.height();
        var margin = iconSize * 1.2;

        boxImage.toggle(function() {

            blocks.each(function(n) {
                $(this).animate({
                    'bottom': boxImageHeight + margin * n,
                    'left': '100px'
                }, 1000);
            });

            spans.fadeIn(1000);

        }, function() {

            blocks.each(function(n) {
                $(this).animate({
                    'bottom': bottom[n],
                    'left': left[n]
                }, 1000);
            });
            spans.fadeOut(1000);
        });
    });
};