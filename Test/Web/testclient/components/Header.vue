<template>
  <div>
    <b-navbar type="dark" variant="dark">
      <b-navbar-nav>
        <b-nav-item href="/">Libreria</b-nav-item>

        <!-- Navbar dropdowns -->
        <b-nav-item-dropdown text="Menu" right>
          <b-dropdown-item href="/weather">Prueba</b-dropdown-item>
          <b-dropdown-item href="/book">Libros</b-dropdown-item>
          <b-dropdown-item href="/editorial">Editoriales</b-dropdown-item>
        </b-nav-item-dropdown>
      </b-navbar-nav>
    </b-navbar>
  </div>
</template>

<script>
export default {};
</script>

<style></style>
