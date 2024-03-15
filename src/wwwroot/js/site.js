function previewImage(event, previewId) {
    var input = event.target;
    var image = document.getElementById(previewId);
    if (input.files && input.files[0]) {
       var reader = new FileReader();
       reader.onload = function(e) {
          image.src = e.target.result;
       }
       reader.readAsDataURL(input.files[0]);
    }
 }