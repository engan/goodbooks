<template>
<div class="book-wrapper">
    <div class="book-title">
        {{ book.title }}
    </div>
    <div class="book-author">
        {{ book.author }}
    </div>
    <div class="book-created">
        {{ book.createdOn | humanize }}
    </div>
    <div @click="deleteBook(book.id)" class="delete">
        X
    </div>        
</div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator'
import IBook from '../types/Book'
import BooksService from "../services/book-service"

const bookService = new BooksService();

@Component( {
    name: "Book",
    components: {}
})
export default class Book extends Vue {
    @Prop({ required: true })
    book!: IBook;

    async deleteBook( id: number ) {
        await bookService.deleteBook(id);
        this.$emit('deleted', id);
    }
}
</script>

<style scoped lang="scss">
    .book-wrapper {
        position: relative;
        margin: 0.8rem;
        padding: 0.4rem;
        background-color: #fafafa;
        border-radius: 1rem;
        box-shadow: 0 1px 3px rgba(0,0,0,0.12), 0 1px 2px rgba(0,0,0,0.24);
    }
    .book-title {
        font-size: 1.2rem;
        font-weight: bold;
    }
    .book.author {
        color: #333;
    }
    .book-created {
        font-size: 0.9rem;
        color: #333;
    }
    .delete {
        position: absolute;
        top: 10px;
        right: 10px;
        font-size: 0.9rem;
        color: #ce3355;
        cursor: pointer;
    }
</style>