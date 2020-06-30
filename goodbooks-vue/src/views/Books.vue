<template>
  <div class="books-container">
    <h1>My Books</h1>
    <div v-if="myBooks.length">
      <book
        @deleted="getAllBooks"
        :book="book"
        v-for="book in myBooks"
        :key="book.id">
      </book>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import IBook from '../types/Book';
import BookService from '../services/book-service';
import Book from '@/components/Book.vue'

const bookService = new BookService();

@Component({
  name: 'MyBooks',
  components: { Book }
})
export default class MyBooks extends Vue {
  // Explanations of all definitions at: 
  // https://www.youtube.com/watch?v=KNfceHrwmvg&t=297

  // data (see import above)
  myBooks: IBook[] = [];

  // computed properties (value chached)
  get bookCount() {
    return this.myBooks.length;
  }

  getAllBooks() {
    bookService.getAllBooks()
      .then(res => this.myBooks = res)
      .catch(err => console.error(err));
  }

  // props

  // methods

  // lifecycle hooks
  created() {
    this.getAllBooks();
  }

}

  // watchers (more complex version of computed properties)
</script>

<style lang="scss">

</style>
