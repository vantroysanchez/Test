<template>
  <div>
    <b-jumbotron
      header="Mantenimientos de libreria"
      lead="Ejemplo básico de mantenimientos con Nuxt js y .Net core"
    >
    </b-jumbotron>
    <div class="m-3">
      <b-card-group deck>
        <b-card bg-variant="light" header="Libros" class="text-center">
          <b-card-text>
            <nuxt-link to="/book" class="text-secondary">
              Mantenimiento para gestión de libros.
            </nuxt-link>
          </b-card-text>
        </b-card>
        <b-card bg-variant="light" header="Editoriales" class="text-center">
          <b-card-text>
            <nuxt-link to="/editorial" class="text-secondary">
              Mantenimiento para gestión de las editoriales de los libros.
            </nuxt-link>
          </b-card-text>
        </b-card>
      </b-card-group>
    </div>
  </div>
</template>

<script>
export default {
  layout: "default",
  name: "IndexPage",
  data() {
    return {
      title: "Mi página",
    };
  },
};
</script>
