<template>
  <div>
    <b-card title="Usuarios " sub-title="Mantenimiento de usuarios">
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
          key: "userName",
          label: "Nombre",
        },
        {
          key: "lastName",
          label: "Apellido",
        },
        {
          key: "book.description",
          label: "Libro",
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
        .get("https://localhost:44377/api/User")
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
        title: "Eliminar usuario",
        text: "¿Está seguro que desea eliminar este usuario?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
      }).then((willDelete) => {
        if (willDelete) {
          axios
            .delete(`https://localhost:44377/api/User/${id}`)
            .then((result) => {
              swal("¡Usuario eliminado!", {
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
