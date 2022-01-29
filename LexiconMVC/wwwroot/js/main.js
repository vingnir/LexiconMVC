

// setup typewriter effect in the terminal demo
if (document.getElementsByClassName('demo').length > 0) {
    var i = 0;
    var txt = `Core information... 
            [Entry mode; press Ctrl+D to save and quit; press Ctrl+C to quit without saving]

            #TODO: Get a garden, play more with the dogs, write even better code 

            - Name = Johan Daniel Ivarsson
            - Age = 40
            - Location = Gamlestaden, Gothenburg
            - Interests = Dogs, plants and coding
            - Languages = C#, JS, PHP, Java, SQL
            - Tech = HTML, CSS, SASS, XML, CCNA, Linux ...
            - Creative solutions? true
            - Fullstack = true`;
    var speed = 60;

    function typeItOut() {
        if (i < txt.length) {
            document.getElementsByClassName('demo')[0].innerHTML += txt.charAt(i);
            i++;
            setTimeout(typeItOut, speed);
        }
    }

    setTimeout(typeItOut, 1400);
}
