# Unit XXIV Assignment III
*By Nathan Windisch*

## PIV: Implementation
The following are pieces of code from individual classes. I shall comment lines that I believe are important.

### Main.java
```java
package net.survivalz.chill; // sets the package name so that the compiler knows what to do

import net.survivalz.chill.events.*; // imports various APIs from bukkit and other classes
import org.bukkit.ChatColor;
import org.bukkit.entity.HumanEntity;
import org.bukkit.entity.Player;
import org.bukkit.plugin.PluginManager;
import org.bukkit.plugin.java.JavaPlugin;

import java.util.ArrayList; // imports APIs from Java itself
import java.util.UUID;

public class ChillMain extends JavaPlugin { // the main class, where the magic happens, extends JavaPlugin so that the server knows to run it
    public static ArrayList<UUID> frozen = new ArrayList<>(); // creating the list that will be populated with frozen player's UUIDs
    public final static String prefix = (ChatColor.GOLD + "[" + ChatColor.YELLOW + "Colossal" + ChatColor.GOLD + "]" + ChatColor.DARK_AQUA + " "); // setting up the colours and prefixes so that I can call them easily later
    public final static ChatColor pri = ChatColor.DARK_AQUA;
    public final static ChatColor sec = ChatColor.GREEN;
    public final static String TeamSpeakStr = "TS.ColossalMC.net";

    public static void blank(Player player) { // a function that clears the player's chat, will be called a lot
        for (int i = 0; i < 1; ++i) {
            player.sendMessage("");
        }
    }

    private onBlockBreak onBlockBreakEvent = new onBlockBreak(this); // creates new varaibles for all of the events that are used and sets them to that event
    private onBlockPlace onBlockPlaceEvent = new onBlockPlace(this);
    private onCommandPreprocess onCommandPreprocessEvent = new onCommandPreprocess(this);
    private onEnderpearlThrow onEnderpearlThrow = new onEnderpearlThrow(this);
    private onFrozenGiveDamage onFrozenGiveDamageEvent = new onFrozenGiveDamage(this);
    private onPlayerDropItem onPlayerDropItemEvent = new onPlayerDropItem(this);
    private onInventoryCloseEvent onInventoryCloseEvent = new onInventoryCloseEvent(this);
    private onPlayerInventoryClickItem onPlayerInventoryClickItem = new onPlayerInventoryClickItem(this);
    private onPlayerMove onPlayerMoveEvent = new onPlayerMove(this);
    private onPlayerPickupItem onPlayerPickupItem = new onPlayerPickupItem(this);
    private onPlayerQuit onPlayerQuitEvent = new onPlayerQuit(this);
    private onPlayerTakeDamage onPlayerTakeDamageEvent = new onPlayerTakeDamage(this);
    private onPlayerTeleport onPlayerTeleport = new onPlayerTeleport(this);

    public void onEnable() { // required in all plugins
        PluginManager pluginManager = getServer().getPluginManager(); // starts to register tthe events
        pluginManager.registerEvents(onBlockBreakEvent, this); // registers all events used
        pluginManager.registerEvents(onBlockPlaceEvent, this);
        pluginManager.registerEvents(onCommandPreprocessEvent, this);
        pluginManager.registerEvents(onFrozenGiveDamageEvent, this);
        pluginManager.registerEvents(onInventoryCloseEvent, this);
        pluginManager.registerEvents(onPlayerDropItemEvent, this);
        pluginManager.registerEvents(onPlayerInventoryClickItem, this);
        pluginManager.registerEvents(onPlayerMoveEvent, this);
        pluginManager.registerEvents(onPlayerPickupItem, this);
        pluginManager.registerEvents(onPlayerQuitEvent, this);
        pluginManager.registerEvents(onPlayerTakeDamageEvent, this);

        getCommand("freeze").setExecutor(new onCommand(this)); // registers all commands used
        getCommand("ss").setExecutor(new onCommand(this));
        getCommand("frozen").setExecutor(new onCommand(this));
        getCommand("thaw").setExecutor(new onCommand(this));
        getCommand("unfreeze").setExecutor(new onCommand(this));
        getCommand("sscheck").setExecutor(new onCommand(this));
        getCommand("checkss").setExecutor(new onCommand(this));
        getCommand("checkfreeze").setExecutor(new onCommand(this));
        getCommand("freezecheck").setExecutor(new onCommand(this));
        getCommand("panic").setExecutor(new onCommand(this));
        getCommand("chill").setExecutor(new onCommand(this));
        getCommand("freezehelp").setExecutor(new onCommand(this));
        getCommand("helpfreeze").setExecutor(new onCommand(this));
        getCommand("sshelp").setExecutor(new onCommand(this));
        getCommand("helpss").setExecutor(new onCommand(this));
    }

    public void onDisable() { } // required by default. as we are not saving anything when the plugin disables, nothing is needed here
}
```

### MenuItems.java
```java
package net.survivalz.chill;

import org.bukkit.ChatColor;
...

import java.util.ArrayList;

public class MenuItems {
    public static ItemStack close() { // creates a new item that I can call later
        ItemStack item = new ItemStack(Material.STAINED_GLASS_PANE, 0, (short) 14); // sets the item to be a stained glass pane with the metadata of 14, meaning that the colours is set to red
        ItemMeta itemMeta = item.getItemMeta(); // starting to set the itemmeta
        itemMeta.setDisplayName(ChatColor.RED + "Close Menu"); // sets the item's name
        ArrayList<String> lore = new ArrayList<>(); // sets the item's lore, unneeded in this context
        lore.add("");
        itemMeta.setLore(lore); // adds lore to the item
        item.setAmount(1); // sets the amount of items in the stack to be 1
        item.setItemMeta(itemMeta); // applies the itemmeta to the item

        return item; // returns the final item
    }

    public static ItemStack info() {
        ItemStack item = new ItemStack(Material.PAPER);
        ...

        return item;
    }

    public static ItemStack admit() {
        ItemStack item = new ItemStack(Material.STAINED_GLASS_PANE, 0, (short) 5);
        ... 

        return item;
    }
}
```

### onCommand.java
```java
package net.survivalz.chill;

import net.survivalz.chill.events.FrozenMenu;
import org.bukkit.Bukkit;
import org.bukkit.ChatColor;
import org.bukkit.GameMode;
import org.bukkit.Location;
import org.bukkit.command.Command;
import org.bukkit.command.CommandExecutor;
import org.bukkit.command.CommandSender;
import org.bukkit.entity.Entity;
import org.bukkit.entity.Player;
import org.bukkit.potion.PotionEffect;
import org.bukkit.potion.PotionEffectType;

public class onCommand implements CommandExecutor { // sets this class to be the place where all the commands can be found
    public ChillMain plugin; // these next few lines link back to the main plugin, for referencing
    public onCommand (ChillMain plugin) {
        this.plugin = plugin;
    }

    public boolean onCommand(CommandSender sender, Command cmd, String commandlabel, String[] args) { // starting to create commands
        String prefix = plugin.prefix; // setting up local variables of the prefix and colours
        ChatColor pri = plugin.pri;
        ChatColor sec = plugin.sec;
        if (commandlabel.equalsIgnoreCase("freeze") || commandlabel.equalsIgnoreCase("ss")) { // if the command is "/freeze" and if they have the permission "chill.freeze", as seen below
            if (sender.hasPermission("chill.freeze")) {
                if (args.length == 0) { // if they dont have any arguments, display help text
                    sender.sendMessage(prefix + "Please specify a " + sec + "player" + pri + ".");
                    return true;
                }
                if (args[0].equalsIgnoreCase("*") || args[0].equalsIgnoreCase("all")) { if they try to freeze all and have the perm ,go through the security steps
                    if (!sender.hasPermission("chill.freeze.all")) {
                        sender.sendMessage(prefix + "You do " + sec + "not " + pri + "have permission to perform this " + sec + "command" + pri + ".");
                        return true;
                    } else {
                        sender.sendMessage(prefix + "This is in " + sec + "development" + pri + ".");
                        if (args.length == 1) {
                            sender.sendMessage(prefix + "This is a " + sec + "very " + pri + "serious command.");
                            sender.sendMessage(prefix + "This freezes " + sec + "all " + pri + "online players.");
                            sender.sendMessage(prefix + "If you are okay with this, type " + sec + "/freeze all confirm");
                        } else if (args.length < 1) {
                            if (args[1].equalsIgnoreCase("confirm")) {
                                for (Player player : Bukkit.getOnlinePlayers()) {
                                    if (plugin.frozen.contains(player)) {
                                        plugin.frozen.add(player.getUniqueId());
                                        sender.sendMessage(prefix + "Froze " + sec + player.getName() + pri + ".");
                                    }
                                }
                                return true;
                            } else {
                                sender.sendMessage(prefix + "This is a " + sec + "very " + pri + "serious command.");
                                sender.sendMessage(prefix + "This freezes " + sec + "all " + pri + "online players.");
                                sender.sendMessage(prefix + "If you are okay with this, type " + sec + "/freeze all confirm");
                                return true;
                            }
                        }
                        return true;
                    }
                }

                Entity targetEntity = Bukkit.getServer().getPlayer(args[0]); // creates a temporary entity placeholder that will be what the player's first arg is
                if (targetEntity instanceof Player) { // checks if the entity selected is really a player, just in case
                    Player target = (Player) targetEntity; sets the entity to be a player
                    if (target == null || !Bukkit.getOnlinePlayers().contains(target)) { if the player isnt real, throw error
                        sender.sendMessage(prefix + sec + target.getName() + pri + " does not " + sec + "exist" + pri + ". " + sec + "(" + args[0] + ")");
                        return true;
                    }
                    if (target.isOp() || target.hasPermission("chill.override")) { // if the target has override perms, don't freeze them for security measures
                        sender.sendMessage(prefix + pri + "You cannot freeze " + sec + target.getName() + pri + ".");
                        for (Player all : Bukkit.getOnlinePlayers()) {
                            if (all.hasPermission("chill.notify")) {
                                all.sendMessage(prefix + sec + sender.getName() + pri + " tried to freeze " + sec + target.getName() + pri + " but they had the permission " + sec + "chill.override" + pri + ".");
                            }
                        }
                        return true;
                    } else {
                        if (plugin.frozen.contains(target.getUniqueId())) { // if selected player is already frozen, unfreeze and notify all staff
                            plugin.frozen.remove(target.getUniqueId());
                            for (Player all : Bukkit.getOnlinePlayers()) {
                                if (all.hasPermission("chill.notify")) {
                                    all.sendMessage(prefix + sec + sender.getName() + pri + " just unfroze " + sec + target.getName() + pri + ". ");
                                }
                            }
                            target.removePotionEffect(PotionEffectType.BLINDNESS);
                            sender.sendMessage(prefix + sec + target.getName() + pri + " has been " + sec + "unfrozen" + pri + "!");
                            target.sendMessage(prefix + "You have been " + sec + "unfrozen" + pri + "!");
                            target.closeInventory();
                            return true;
                        }
                        plugin.frozen.add(target.getUniqueId()); // else add them to the frozen list and notify staff
                        sender.sendMessage(prefix + sec + target.getName() + pri + " has been " + sec + "frozen" + pri + "!");
                        for (Player all : Bukkit.getOnlinePlayers()) {
                            if (all.hasPermission("chill.notify")) {
                                all.sendMessage(prefix + sec + sender.getName() + pri + " just froze " + sec + target.getName() + pri + ". ");
                            }
                        }
                        target.addPotionEffect(new PotionEffect(PotionEffectType.BLINDNESS, Integer.MAX_VALUE, 9));
                        plugin.blank(target);
                        target.sendMessage(prefix + "You have been " + sec + "frozen" + pri + "!");
                        target.sendMessage(Strings.joinTS1);
                        target.sendMessage(Strings.joinTS2);
                        return true;
                    }
                }
            } else { // tell the player if they dont have perms
                sender.sendMessage(prefix + "You do " + sec + "not " + pri + "have permission to perform this " + sec + "command" + pri + ".");
                return true;
            }
        }

        if (commandlabel.equalsIgnoreCase("thaw") || commandlabel.equalsIgnoreCase("unfreeze")) { // unfreezes player selected, same logic as above
            if (sender.hasPermission("chill.freeze")) {
                if (args.length == 0) {
                    sender.sendMessage(prefix + "Please specify a " + sec + "player" + pri + ".");
                    return true;
                } else {
                    Entity targetEntity = Bukkit.getServer().getPlayer(args[0]);
                    ...
                    }
                }
            } else {
                sender.sendMessage(prefix + "You do " + sec + "not " + pri + "have permission to perform this " + sec + "command" + pri + ".");
                return true;
            }
        }

        if (commandlabel.equalsIgnoreCase("panic")) { // lets famous people freeze themselves as they are more likely to be targeted. cannot unfreeze, like the opposite of /thaw
            Player player = (Player) sender;
            if (!sender.hasPermission("chill.panic")) {
                sender.sendMessage(prefix + "You do " + sec + "not " + pri + "have permission to perform this " + sec + "command" + pri + ".");
                return true;
            } else {
                if (!plugin.frozen.contains(player.getUniqueId())) {
                    plugin.frozen.add(player.getUniqueId());
                    ...
                } else {
                    sender.sendMessage(prefix + "You are already in " + sec + "/panic mode" + pri + ".");
                    return true;
                }
            }
        }

        if (commandlabel.equalsIgnoreCase("frozen")) { // checks if the player is frozen, same logic as /freeze
            if (!sender.hasPermission("chill.frozen")) {
                sender.sendMessage(prefix + "You do " + sec + "not " + pri + "have permission to perform this " + sec + "command" + pri + ".");
                return true;
            } else {
                if (args.length == 0) {
                    sender.sendMessage(prefix + "Please specify a " + sec + "player" + pri + ".");
                    return true;
                } else if (args.length == 1) {
                    Player target = Bukkit.getServer().getPlayer(args[0]);
                    if (target == null) {
                        sender.sendMessage(prefix + sec + args[0] + pri + " does not " + sec + "exist " + pri + "or is not " + sec + "online" + pri + ".");
                        return true;
                    } else {
                        if (plugin.frozen.contains(target.getUniqueId())) {
                            sender.sendMessage(prefix + sec + target.getName() + pri + " is currently " + sec + "frozen" + pri + ".");
                            return true;
                        } else {
                            sender.sendMessage(prefix + sec + target.getName() + pri + " is " + sec + "not " + pri + "currently " + sec + "frozen" + pri + ".");
                            return true;
                        }
                    }
                } else {
                    sender.sendMessage(prefix + "Too little or few " + sec + "arguments" + pri + ".");
                    return true;
                }
            }
        }
        if (commandlabel.equalsIgnoreCase("chill")) { //outputs plugin information 
            sender.sendMessage("");
            sender.sendMessage(prefix + sec + "/freeze <playerName> " + pri + "- Freezes/Unfreezes a player, used as a toggle. " + sec + "chill.freeze");
            sender.sendMessage(prefix + sec + "/frozen <playerName> " + pri + "- Checks if a player is frozen. " + sec + "chill.frozen");
            sender.sendMessage(prefix + sec + "/panic " + pri + "- Places you into panic mode, whereby you cannot be unfrozen. " + sec + "chill.panic");
            sender.sendMessage("");
            sender.sendMessage(prefix + "Created by " + sec + "Natfan" + pri + ". " + sec + "http://natfan.github.io/");
            sender.sendMessage(prefix + "For the " + sec + "Colossal Network" + pri + ". " + sec + "http://colossalmc.net/");
            sender.sendMessage("");
            return true;
        }
        return true;
    }
}
```

### Events
#### FrozenMenu.java
```java
package net.survivalz.chill.events;

import net.survivalz.chill.MenuItems;
import org.bukkit.Bukkit;
import org.bukkit.ChatColor;
import org.bukkit.entity.Player;
import org.bukkit.event.inventory.ClickType;
import org.bukkit.inventory.Inventory;
import org.bukkit.inventory.ItemStack;

public class FrozenMenu {
    public static Inventory inv = Bukkit.createInventory(null, 8, ChatColor.GOLD + "Frozen Menu"); // creates the menu, sets it to be 1 row (9 spaces wide), sets the name of the menu and sets the owner to be null so that anyone can access

    static {
        inv.setItem(2, MenuItems.admit()); // sets the specific slots to be specific items
        inv.setItem(4, MenuItems.info());
        inv.setItem(6, MenuItems.close());
    }
}
```

#### onBlockBreak.java
```java
package net.survivalz.chill.events;

import net.survivalz.chill.ChillMain;
import net.survivalz.chill.Strings;
import org.bukkit.ChatColor;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.block.BlockBreakEvent;

public class onBlockBreak implements Listener { // tells the server that this listens for events
    public ChillMain plugin;
    public onBlockBreak (ChillMain plugin) {
        this.plugin = plugin;
    }

    @EventHandler // required for listeners
    public void onBlockBreakEvent(BlockBreakEvent e) { // activates whenever a block breaks
        String prefix = plugin.prefix;
        ChatColor pri = plugin.pri;
        ChatColor sec = plugin.sec;

        Player p = e.getPlayer(); // sets a local var to be the player that broke the block
        if (plugin.frozen.contains(p.getUniqueId())) { // if they're frozen...
            e.setCancelled(true); // cancel the event
            plugin.blank(p);
            p.sendMessage(prefix + "You are currently " + sec + "frozen " + pri + "and cannot " + sec + "break " + pri + "blocks!");
            p.sendMessage(Strings.joinTS1);
            p.sendMessage(Strings.joinTS2);
        }
    }
}
```

#### onBlockPlace.java
```java
package net.survivalz.chill.events;

import net.survivalz.chill.ChillMain;
import net.survivalz.chill.Strings;
import org.bukkit.ChatColor;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.block.BlockPlaceEvent;

public class onBlockPlace implements Listener {
    public ChillMain plugin;
    public onBlockPlace (ChillMain plugin) {
        this.plugin = plugin;
    }

    @EventHandler
    public void onBlockPlaceEvent(BlockPlaceEvent e) { // checks when a block is placed
        String prefix = plugin.prefix;
        ChatColor pri = plugin.pri;
        ChatColor sec = plugin.sec;

        Player p = e.getPlayer();
        if (plugin.frozen.contains(p.getUniqueId())) { // cancels the event if player is frozen
            e.setCancelled(true);
            plugin.blank(p);
            p.sendMessage(prefix + "You are currently " + sec + "frozen " + pri + "and cannot " + sec + "place " + pri + "blocks!");
            p.sendMessage(Strings.joinTS1);
            p.sendMessage(Strings.joinTS2);
        }
    }
}
```

#### onCommandPreprocess.java
```java
package net.survivalz.chill.events;

import net.survivalz.chill.ChillMain;
import net.survivalz.chill.Strings;
import org.bukkit.ChatColor;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.player.PlayerCommandPreprocessEvent;

public class onCommandPreprocess implements Listener {
    public ChillMain plugin;
    public onCommandPreprocess(ChillMain plugin) {
        this.plugin = plugin;
    }

    @EventHandler
    public void onCommandPreprocess(PlayerCommandPreprocessEvent e) { // fires whenever a command is sent
        String prefix = plugin.prefix;
        ChatColor pri = plugin.pri;
        ChatColor sec = plugin.sec;

        Player p = e.getPlayer();
        if (plugin.frozen.contains(p.getUniqueId())) { // cancels the event if player is frozen
            if (!e.getMessage().startsWith("/thaw " + p.getName()) || !e.getMessage().startsWith("/unfreeze " + p.getName())) {
                e.setCancelled(true);
                plugin.blank(p);
                p.sendMessage(prefix + "You are currently " + sec + "frozen " + pri + "and cannot " + sec + "type " + pri + "commands!");
                p.sendMessage(Strings.joinTS1);
                p.sendMessage(Strings.joinTS2);
            }
        }
    }
}
```

#### onEnderpearlThrow
```java
package net.survivalz.chill.events;

import net.survivalz.chill.ChillMain;
import org.bukkit.ChatColor;
import org.bukkit.entity.EnderPearl;
import org.bukkit.entity.Entity;
import org.bukkit.entity.Player;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.entity.ProjectileLaunchEvent;

public class onEnderpearlThrow implements Listener {
    public ChillMain plugin;

    public onEnderpearlThrow(ChillMain plugin) {
        this.plugin = plugin;
    }

    @EventHandler
    public void onEnderpearlThrowEvent(ProjectileLaunchEvent e) { // fires when any projectile is thrown
        String prefix = plugin.prefix;
        ChatColor pri = plugin.pri;
        ChatColor sec = plugin.sec;

        Entity entity = e.getEntity();
        if (entity instanceof EnderPearl) { // checks if the projectile is an enderpearl, an item which lets the player teleport
            Player player = (Player) ((EnderPearl) entity).getShooter(); // get the person who thew the enderpearl
            if (plugin.frozen.contains(player.getUniqueId())) {
                player.sendMessage(prefix + sec + "You " + pri + "are currently " + sec + "frozen " + pri + "and cannot " + sec + "use " + pri + "Ender Pearls!");
                e.setCancelled(true); // cancels if the player is frozen
            }
        }
    }
}
```
