<template>
  <div>
    <b-modal v-model="showModalEdit" id="modal-edit" size="lg">
      <template #modal-title> Editar Usuario </template>
      <div>
        <b-form>
          <b-row>
            <b-col>
              <label class="mr-sm-2" for="inline-form-input-name"
                >Nombre</label
              >
              <b-form-input
                id="inline-form-input-name"
                class="mb-2 mr-sm-2 mb-sm-0"
                placeholder="Nombre del libro"
                v-model="user.userName"
              ></b-form-input>
            </b-col>
                        <b-col>
              <label class="mr-sm-2" for="inline-form-input-name"
                >Apellido</label
              >
              <b-form-input
                id="inline-form-input-name"
                class="mb-2 mr-sm-2 mb-sm-0"
                placeholder="Nombre del libro"
                v-model="user.lastName"
              ></b-form-input>
            </b-col>
            <b-col>
              <label class="mr-sm-2">Libro</label>
              <b-form-select v-model="user.bookId">
                <b-form-select-option
                  :key="index"
                  v-for="(item, index) in book"
                  :value="item.id"
                  >{{ item.description }}</b-form-select-option
                >
              </b-form-select>
            </b-col>
          </b-row>
        </b-form>
      </div>
      <template #modal-footer>
        <div class="w-100">
          <b-button
            variant="primary"
            size="sm"
            class="float-right"
            @click="Save(user.id)"
          >
            Guardar
          </b-button>
          <b-button
            variant="default"
            size="sm"
            class="float-right"
            @click="showModalEdit = false"
          >
            Cerrar
          </b-button>
        </div>
      </template>
    </b-modal>
  </div>
</template>

<script>
import axios from "axios";
import swal from "sweetalert";

export default {
  props: ["EntityId"],
  layout: "default",
  data() {
    return {
      showModalEdit: false,
      user: {
        userName:"",
        lastName:"",
        description: "",
        bookId: 1,
        book: null,
      },
      book: [{}],
    };
  },
  methods: {
    getUser(id) {
      axios
        .get(`https://localhost:44377/api/User/${id}`)
        .then((result) => {
          this.user = result.data;
        });
    },

    getBook() {
      axios
        .get("https://localhost:44377/api/Book")
        .then((result) => {
          this.book = result.data.$values;
        });
    },

    Save(id) {
        debugger
      axios
        .put(`https://localhost:44377/api/User/${id}`, this.user)
        .then((result) => {
          swal(
            "Guardado",
            "¡Información guardada satisfactoriamente!",
            "success"
          );
          this.$router.go(0);
        });
    },
  },
  watch: {
    EntityId(newValue, oldValue) {
      this.getUser(newValue);
    },
  },
  created() {
    this.getBook();
  },
};
</script>

<style></style>