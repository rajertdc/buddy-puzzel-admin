document.getElementById('sidebar-catalog').addEventListener('click', function(event) {
    event.preventDefault();
    alert('Overwritten by JavaScript!');
    window.location.href = `/Customers/CustomerSite/${id}/Catalogs`;
});