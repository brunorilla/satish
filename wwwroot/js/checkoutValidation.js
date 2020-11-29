

var formIsValid = false;


function validateDni() {
    var formInput = document.getElementById('dnisubmit');
    formInput.addEventListener('click',
        function(e) {
            e.preventDefault();
            if (formIsValid) {
                var form = document.querySelector('form');
                form.submit();


            }

        });

}


var dni = document.getElementById("dnivalid");
dni.addEventListener('change',
    function() {
        var spanValid = document.querySelector('.dnivalid');
        var spanNotValid = document.querySelector('.dni-notvalid');
        if (!(dni.value < 2147483647 && dni.value > 999999)) {
            if(!spanNotValid.classList.contains("show")){
                spanNotValid.classList.toggle('show');
                if (spanValid.classList.contains('show')) {
                    spanValid.classList.toggle('show');
                }
                
            }
            formIsValid = false;
        } else {
            console.log(dni.value + " formato válido");
            if(!(spanValid.classList.contains('show'))) {
                spanValid.classList.toggle('show');
                if (spanNotValid.classList.contains('show')) {
                    spanNotValid.classList.toggle('show');
                }
            }
                
            formIsValid = true;
        }
    });

window.addEventListener('load',
    function() {
        validateDni();
    })