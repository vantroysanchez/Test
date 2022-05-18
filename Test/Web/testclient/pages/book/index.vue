<template>
  <div>
    <b-card title="Libros" sub-title="Mantenimiento de los libros">
      <create />
      <edit :EntityId="IdEditValue" />
      <b-table v-if="items" striped hover :items="items" :fields="fields">
        <template #cell(action)="row">
          <b-button
            @click="edit(row.item.id)"
            v-b-modal.modal-edit
            size="sm"
            class="mr-2"
          >
            Editar
          </b-button>
          <b-button
            size="sm"
            @click="remove(row.item.id)"
            class="mr-2"
            variant="danger"
          >
            Eliminar
          </b-button>
        </template>
      </b-table>
    </b-card>
  </div>
</template>

<script>
import axios from "axios";
import create from "./create.vue";
import edit from "./edit.vue";
import swal from "sweetalert";

export default {
  components: { create, edit },
  layout: "default",
  data() {
    return {
      Id: 1,
      fields: [
        {
          key: "id",
        },
        {
          key: "description",
        },
        {
          key: "status",
          formatter: (value) => {
            if (value) return "Activo";

            return "Inactivo";
          },
        },
        {
          key: "editorial.description",
          label: "Editorial",
        },
        {
          key: "action",
          label: "Action",
        },
      ],
      items: [{}],
    };
  },
  methods: {
    getAll() {
      axios
        .get("https://localhost:44377/api/Book")
        .then((result) => {
          this.items = result.data.$values;
        });
    },
    edit(id) {
      this.showModalEdit = true;
      this.Id = id;
    },
    remove(id) {
      swal({
        title: "Eliminar libro",
        text: "¿Está seguro que desea eliminar este libro?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
      }).then((willDelete) => {
        if (willDelete) {
          axios
            .delete(`https://localhost:44377/api/Book/${id}`)
            .then((result) => {
              swal("¡Libro eliminado!", {
                icon: "success",
              });
              this.$router.go(0);
            })
            .catch((e) => {
              swal("Ocurrió un error al eliminar el registro.", {
                icon: "danger",
              });
              this.$router.go(0);
            });
        }
      });
    },
  },
  computed: {
    IdEditValue() {
      return this.Id;
    },
  },
  created() {
    this.getAll();
  },
};
</script>

<style scoped></style>
