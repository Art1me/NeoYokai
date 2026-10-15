package com.neoyokai.server.entity;

import jakarta.persistence.*;

@Entity
@Table(name = "ronins")
public class Ronin {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false, length = 50)
    private String name;

    @Column(nullable = false)
    private String characterClass; // Например: "Кибер-Самурай" или "Хакер"

    @Column(nullable = false)
    private Integer level = 1;

    // Связь обратно к аккаунту
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "account_id", nullable = false)
    private Account account;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getCharacterClass() {
        return characterClass;
    }

    public void setCharacterClass(String characterClass) {
        this.characterClass = characterClass;
    }

    public Integer getLevel() {
        return level;
    }

    public void setLevel(Integer level) {
        this.level = level;
    }

    public Account getAccount() {
        return account;
    }

    public void setAccount(Account account) {
        this.account = account;
    }
// В IntelliJ IDEA нажми Alt + Insert -> Getter and Setter, чтобы сгенерировать методы
}