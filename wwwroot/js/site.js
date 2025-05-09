
const openNav = document.querySelector("#openNav")
const closeNav = document.getElementById("closeNav")
const mobileNav = document.getElementById("mobileNav")
const desktopNav = document.getElementById("desktopNav")


openNav?.addEventListener("click", function(e){
    mobileNav.classList.remove("hidden")
    desktopNav.classList.add("hidden")
})

closeNav?.addEventListener("click", function(e){
    desktopNav.classList.remove("hidden")
    mobileNav.classList.add("hidden")
})