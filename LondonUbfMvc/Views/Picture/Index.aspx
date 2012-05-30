<%@ Import Namespace="LondonUbfWeb.Helpers" %>

<html> 
    <head> 
        <meta http-equiv="Content-type" content="text/html; charset=utf-8"> 
        <title>Galleriffic | Thumbnail rollover effects and slideshow crossfades</title> 

        <%= Html.Css("gbasic.css") %>
        <%= Html.Css("galleriffic-2.css")%>
        <%= Html.Script("jquery-1.3.2.js") %>
        <%= Html.Script("jquery.galleriffic.js") %>
        <%= Html.Script("jquery.opacityrollover.js") %>
    </head> 
    <body> 
        <div id="page"> 
            <div id="container"> 
                <h1><a href="index.html">Galleriffic</a></h1> 
                <h2>Thumbnail rollover effects and slideshow crossfades</h2> 
 
                <!-- Start Advanced Gallery Html Containers --> 
                <div id="gallery" class="content"> 
                    <div id="controls" class="controls"></div> 
                    <div class="slideshow-container"> 
                        <div id="loading" class="loader"></div> 
                        <div id="slideshow" class="slideshow"></div> 
                    </div> 
                    <div id="caption" class="caption-container"></div> 
                </div> 
                <div id="thumbs" class="navigation"> 
                    <ul class="thumbs noscript"> 

                        <li> 
                            <a class="thumb" href="http://farm2.static.flickr.com/1116/1380178473_fc640e097a.jpg" title="Title #22"> 
                                <img src="http://farm2.static.flickr.com/1116/1380178473_fc640e097a_s.jpg" alt="Title #22" /> 
                            </a> 
                            <div class="caption"> 
                                <div class="download"> 
                                    <a href="http://farm2.static.flickr.com/1116/1380178473_fc640e097a_b.jpg">Download Original</a> 
                                </div> 
                                <div class="image-title">Title #22</div> 
                                <div class="image-desc">Description</div> 
                            </div> 
                        </li> 
 
                        <li> 
                            <a class="thumb" href="http://farm2.static.flickr.com/1260/930424599_e75865c0d6.jpg" title="Title #23"> 
                                <img src="http://farm2.static.flickr.com/1260/930424599_e75865c0d6_s.jpg" alt="Title #23" /> 
                            </a> 
                            <div class="caption"> 
                                <div class="download"> 
                                    <a href="http://farm2.static.flickr.com/1260/930424599_e75865c0d6_b.jpg">Download Original</a> 
                                </div> 
                                <div class="image-title">Title #23</div> 
                                <div class="image-desc">Description</div> 
                            </div> 
                        </li> 
                    </ul> 
                </div> 
                <div style="clear: both;"></div> 
            </div> 
        </div> 
        <div id="footer">&copy; 2009 Trent Foley</div> 
        <script type="text/javascript"> 
            jQuery(document).ready(function($) {
                // We only want these styles applied when javascript is enabled
                $('div.navigation').css({'width' : '300px', 'float' : 'left'});
                $('div.content').css('display', 'block');
 
                // Initially set opacity on thumbs and add
                // additional styling for hover effect on thumbs
                var onMouseOutOpacity = 0.67;
                $('#thumbs ul.thumbs li').opacityrollover({
                    mouseOutOpacity:   onMouseOutOpacity,
                    mouseOverOpacity:  1.0,
                    fadeSpeed:         'fast',
                    exemptionSelector: '.selected'
                });
                
                // Initialize Advanced Galleriffic Gallery
                var gallery = $('#thumbs').galleriffic({
                    delay:                     2500,
                    numThumbs:                 15,
                    preloadAhead:              10,
                    enableTopPager:            true,
                    enableBottomPager:         true,
                    maxPagesToShow:            7,
                    imageContainerSel:         '#slideshow',
                    controlsContainerSel:      '#controls',
                    captionContainerSel:       '#caption',
                    loadingContainerSel:       '#loading',
                    renderSSControls:          true,
                    renderNavControls:         true,
                    playLinkText:              'Play Slideshow',
                    pauseLinkText:             'Pause Slideshow',
                    prevLinkText:              '&lsaquo; Previous Photo',
                    nextLinkText:              'Next Photo &rsaquo;',
                    nextPageLinkText:          'Next &rsaquo;',
                    prevPageLinkText:          '&lsaquo; Prev',
                    enableHistory:             false,
                    autoStart:                 false,
                    syncTransitions:           true,
                    defaultTransitionDuration: 900,
                    onSlideChange:             function(prevIndex, nextIndex) {
                        // 'this' refers to the gallery, which is an extension of $('#thumbs')
                        this.find('ul.thumbs').children()
                            .eq(prevIndex).fadeTo('fast', onMouseOutOpacity).end()
                            .eq(nextIndex).fadeTo('fast', 1.0);
                    },
                    onPageTransitionOut:       function(callback) {
                        this.fadeTo('fast', 0.0, callback);
                    },
                    onPageTransitionIn:        function() {
                        this.fadeTo('fast', 1.0);
                    }
                });
            });
        </script> 
    </body> 
</html>