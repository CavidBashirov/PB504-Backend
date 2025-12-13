"use strict";

let deleteCategoryBtns = document.querySelectorAll(".delete-category");


//delete category

deleteCategoryBtns.forEach(function (btn) {
    btn.addEventListener("click", async function (e) {
        e.preventDefault();
        let id = parseInt(this.getAttribute("data-id"));

        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then( async (result) => {
            if (result.isConfirmed) {
                var res = await DeleteCategory(id);
                this.parentNode.parentNode.remove();
                Swal.fire({
                    title: "Deleted!",
                    text: "Your file has been deleted.",
                    icon: "success"
                });
            }
        });
    });
});

async function DeleteCategory(id) {
    const url = `/admin/category/delete?id=${id}`;

    const response = await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        }
    });

    const data = await response.text();
    return data;
}


//delete slider


let deleteSliderBtns = document.querySelectorAll(".delete-slider");

deleteSliderBtns.forEach(function (btn) {
    btn.addEventListener("click", async function (e) {
        e.preventDefault();
        let id = parseInt(this.getAttribute("data-id"));

        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then(async (result) => {
            if (result.isConfirmed) {
                var res = await DeleteSlider(id);
                this.parentNode.parentNode.remove();
                Swal.fire({
                    title: "Deleted!",
                    text: "Your file has been deleted.",
                    icon: "success"
                });
            }
        });
    });
});

async function DeleteSlider(id) {
    const url = `/admin/slider/delete?id=${id}`;

    const response = await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        }
    });

    const data = await response.text();
    return data;
}