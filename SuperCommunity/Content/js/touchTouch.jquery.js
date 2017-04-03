/**
 * @name		jQuery touchTouch plugin
 * @author		Martin Angelov
 * @version 	1.0
 * @url			http://tutorialzine.com/2012/04/mobile-touch-gallery/
 * @license		MIT License
 */

(function () {

    /* Private variables */

    var
        overlayVisible = false;

    $.fn.touchTouch = function (wraperId) {

        var
            index = 0,
            overlay = $('#galleryOverlay_' + wraperId),
            slider = $('#gallerySlider_' + wraperId),
            items = this,
            preloadImagesCount = 2;

        overlay.hide();

        function primaryPreload() {
            for (var i = 0; i <= preloadImagesCount; ++i) {
                preload(index + i);
                preload(index - i);
            }
        }

        //   --------- add listeners ---------

        var placeholders = $('#gallerySlider_' + wraperId + ' > .placeholder').click(function (e) {
            if (!$(e.target).is('img')) {
                hideOverlay();
            }
        });

        $('#prevArrow_' + wraperId).click(function (e) {
            e.preventDefault();
            showPrevious();
        });

        $('#nextArrow_' + wraperId).click(function (e) {
            e.preventDefault();
            showNext();
        });


        // Listening for clicks on the thumbnails

        items.on('click', function (e) {
            e.preventDefault();
            
            // Find the position of this image
            // in the collection

            index = items.index(this);
            showOverlay(index);
            showImage(index);

            primaryPreload();
            
        });

        // Listen for arrow keys
        $(window).bind('keydown', function (e) {

            if (e.keyCode == 37) {
                showPrevious();
            }
            else if (e.keyCode == 39) {
                showNext();
            }

        });


        /* Private functions */


        function showOverlay(imageIndex) {

            // If the overlay is already shown, exit
            if (overlayVisible) {
                return false;
            }

            // Show the overlay
            overlay.show();

            setTimeout(function () {
                // Trigger the opacity CSS transition
                overlay.addClass('visible');
            }, 100);

            // Move the slider to the correct image
            offsetSlider(imageIndex);

            // Raise the visible flag
            overlayVisible = true;
        }

        function hideOverlay() {
            // If the overlay is not shown, exit
            if (!overlayVisible) {
                return false;
            }

            // Hide the overlay
            overlay.hide().removeClass('visible');
            overlayVisible = false;
        }

        function offsetSlider(imageIndex) {
            // This will trigger a smooth css transition
            slider.css('left', (-imageIndex * 100) + '%');
        }

        // Preload an image by its index in the items array
        function preload(index) {
            setTimeout(function () {
                showImage(index);
            }, 1000);
        }

        // Show image in the slider
        function showImage(index) {

            // If the index is outside the bonds of the array
            if (index < 0 || index >= items.length) {
                return false;
            }

            // Call the load function with the href attribute of the item
            loadImage(items.eq(index).attr('href'), function () {
                placeholders.eq(index).html(this);
            });
        }

        // Load the image and execute a callback function.
        // Returns a jQuery object

        function loadImage(src, callback) {
            var img = $('<img>').on('load', function () {
                callback.call(img);
            });

            img.attr('src', src);
        }

        function showNext() {

            // If this is not the last image
            if (index + 1 < items.length) {
                index++;
                offsetSlider(index);
                preload(index + preloadImagesCount);
            }
            else {
                // Trigger the spring animation

                slider.addClass('rightSpring');
                setTimeout(function () {
                    slider.removeClass('rightSpring');
                }, 500);
            }
        }

        function showPrevious() {

            // If this is not the first image
            if (index > 0) {
                index--;
                offsetSlider(index);
                preload(index - preloadImagesCount);
            }
            else {
                // Trigger the spring animation

                slider.addClass('leftSpring');
                setTimeout(function () {
                    slider.removeClass('leftSpring');
                }, 500);
            }
        }
    };

})(jQuery);